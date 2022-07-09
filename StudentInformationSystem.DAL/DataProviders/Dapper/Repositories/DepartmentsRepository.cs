using StudentInformationSystem.DAL.Interfaces;
using StudentInformationSystem.DAL.Models;
using System.Data;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal class DepartmentsRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private const string SELECT_ALL =   @"SELECT * FROM [InfoSystem].[Departments] ";

        private const string GET_BY_ID = @" select * from InfoSystem.Departments where Id= @depo_id
                                            select * from InfoSystem.Students where DepartmentId = @depo_id
                                            select Lectures.* from InfoSystem.Lectures 
                                            inner join InfoSystem.DepartmentLecture 
                                            on Lectures.id= DepartmentLecture.LecturesId AND DepartmentLecture.DepartmentsId = @depo_id";

        private const string REMOVE_BY_ID = @"DELETE FROM [InfoSystem].[Departments] WHERE Id = @depo_id ";

        private const string INSERT_DEPO = @"INSERT INTO [InfoSystem].[Departments] 
                                            (Name, City) 
                                            OUTPUT INSERTED.*
                                            VALUES
                                            (@depo_name, @depo_city)";

        private const string UPDATE_DEPO = @"UPDATE [InfoSystem].[Departments] 
                                             SET    Name = @depo_name, City = @depo_city
                                             WHERE  Id = @depo_id";

        public DepartmentsRepository (IDbConnection dbConnection) : base(dbConnection) { }

        public void AddOrUpdate (IDepartmentEntity entity)
        {
            var entityFilds = new { depo_name = entity.Name, depo_city = entity.City };
            if (entity.Id == 0)
                entity.Id = base.Get(INSERT_DEPO, entityFilds, CommandType.Text).Single( ).Id;
            else
                base.Execute(UPDATE_DEPO, entityFilds, CommandType.Text);
        }

        public IQueryable<IDepartmentEntity> GetAll ( )
        {
            return base.Get(SELECT_ALL);
        }

        public IQueryable<IDepartmentEntity> GetAllByCity (string citySubstring)
        {
            return Get($"{SELECT_ALL}WHERE City LIKE @city_name", new { city_name = $"%{citySubstring}%" });
        }

        public IQueryable<IDepartmentEntity> GetAllByName (string nameSubstring)
        {
            return Get($"{SELECT_ALL}WHERE Name LIKE @depo_name ;", new { depo_name = $"%{nameSubstring}%" });
        }

        public IDepartmentEntity GetById (int id)
        {
            Department depo;
            using (var reader = GetMultiple(GET_BY_ID, new { depo_id = id }))
            {
                depo = reader.Read<Department>( ).Single();
                depo.Students = reader.Read<Student>( ).ToList( );
                depo.Lectures = reader.Read<Lecture>( ).ToList( );                              
            }

            return depo;
        }

        public void Remove (IDepartmentEntity entity)
        {
            Execute(REMOVE_BY_ID, new { depo_id = entity.Id }, CommandType.Text);
        }
    }
}
