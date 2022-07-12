using Dapper;
using StudentInformationSystem.DAL.Interfaces;
using StudentInformationSystem.DAL.Models;
using System.Data;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{

    internal class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private const string SELECT_ALL =
            @"SELECT	S.*, D.[Name] As DepartmentName, D.City AS DepartmentCity
                FROM	InfoSystem.Students S
                LEFT JOIN
		                InfoSystem.Departments D
                ON		S.DepartmentId = D.Id ";      
        
        private const string GET_BY_ID =
            @"  SELECT	S.*, D.Id AS DepoId, D.Name, D.City
                FROM	InfoSystem.Students S
                LEFT JOIN
		                InfoSystem.Departments D
                ON		S.DepartmentId = D.Id ";

        private const string REMOVE_BY_ID =
            @"DELETE FROM [InfoSystem].[Students] WHERE Id = @Id ";

        private const string INSERT_STUDENT =
            @"INSERT INTO [InfoSystem].[Students] 
                (FirstName, LastName, PersonalCode, DepartmentId) 
                OUTPUT INSERTED.*
                VALUES
                (@FirstName, @LastName, @PersonalCode, @DepartmentId)";

        private const string UPDATE_STUDENT =
            @"UPDATE [InfoSystem].[Students] 
                SET    FirstName = @FirstName, LastName = @LastName, PersonalCode = @PersonalCode, DepartmentId = @DepartmentId
                WHERE  Id = @Id";
        public StudentRepository (IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public void AddOrUpdate (IStudentEntity student)
        {
            if (student.Id == 0)
                student.Id = base.Get(INSERT_STUDENT, student, CommandType.Text).Single( ).Id;
            else
                base.Execute(UPDATE_STUDENT, student, CommandType.Text);
        }

        public IQueryable<IStudentEntity> GetAll ( )
        {
            //return Get(SELECT_ALL);
            return base.Connection.Query<Student, Department, Student>(
                  GET_BY_ID,
                  (student, department) =>
                  {
                      department.Id = student.DepartmentId ?? 0;
                      student.Department = department;
                      return student;
                  },
                  splitOn: "DepoId")
              .Distinct( )
              .AsQueryable( );
        }

        public IQueryable<IStudentEntity> GetAllByFirstName (string firstName)
        {
            return Get($"{SELECT_ALL}WHERE FirstName LIKE @FirstName", new { FirstName = $"%{firstName}%" });
        }

        public IQueryable<IStudentEntity> GetAllByLastName (string lastName)
        {
            return Get($"{SELECT_ALL}WHERE LastName LIKE @LastName", new { LastName = $"%{lastName}%" });
        }

        public IStudentEntity GetById (int id)
        {
            return base.Connection.Query<Student, Department, Student>(
                  GET_BY_ID,
                  (student, department) =>
                  {
                      department.Id = student.DepartmentId ?? 0;
                      student.Department = department;
                      return student;
                  },
                  param: new {Id = id},
                  splitOn: "DepoId")
              .Distinct( )
              .First( );
        }

        public IStudentEntity? GetByPersonalCode (string personalCode)
        {
            return Get($"{SELECT_ALL}WHERE PersonalCode = @PersonalCode", new { PersonalCode = $"{personalCode}" }).FirstOrDefault( );
        }

        public void Remove (IStudentEntity student)
        {
            Execute(REMOVE_BY_ID, student, CommandType.Text);
        }
    }
}
