using StudentInformationSystem.DAL.Interfaces;
using System.Data;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    internal  class LecturesRepository : BaseRepository<Lecture>, ILectureRepository
    {
        private const string SELECT_ALL = 
            @"  SELECT * FROM [InfoSystem].[Lectures] ";

        private const string GET_BY_ID =
            @"  SELECT * FROM InfoSystem.Lectures L WHERE L.Id = @lecture_id
                SELECT * FROM InfoSystem.Students S 
                INNER JOIN InfoSystem.LectureStudent LS ON S.Id = LS.StudentsId AND LS.LecturesId = @lecture_id
                SELECT * FROM InfoSystem.Departments D
                INNER JOIN InfoSystem.DepartmentLecture LD ON D.Id = LD.DepartmentsId AND LD.LecturesId = @lecture_id";

        private const string REMOVE_BY_ID = 
            @"  DELETE FROM [InfoSystem].[Lectures] WHERE Id = @lecture_id ";

        private const string INSERT_LECTURE = 
            @"  INSERT INTO [InfoSystem].[Lectures] 
                (Title) 
                OUTPUT INSERTED.*
                VALUES
                (@lecture_title)";

        private const string UPDATE_LECTURE =
            @"  UPDATE [InfoSystem].[Lectures] 
                SET    Title = @lecture_title
                WHERE  Id = @lecture_id";

        private const string GET_BY_STUDENT_ID =
            @"  SELECT L.* FROM InfoSystem.Lectures L
                INNER JOIN InfoSystem.LectureStudent LS ON L.Id = LS.LecturesId AND LS.StudentsId = @student_id
                ";
        private const string GET_BY_DEPARTMENT_ID =
            @"  SELECT L.* FROM InfoSystem.Lectures L
                INNER JOIN InfoSystem.DepartmentLecture DL ON L.Id = DL.DepartmentsId AND DL.DepartmentsId = @department_id";

        public LecturesRepository (IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public void AddOrUpdate (ILectureEntity entity)
        {
            var entityFilds = new { lecture_title = entity.Title};

            if (entity.Id == 0)
                entity.Id = base.Get(INSERT_LECTURE, entityFilds, CommandType.Text).Single( ).Id;
            else
                base.Execute(UPDATE_LECTURE, entityFilds, CommandType.Text);

        }

        public IQueryable<ILectureEntity> GetAll ( )
        {
            return base.Get(SELECT_ALL);
        }

        public IQueryable<ILectureEntity> GetAllByName (string titleSubstring)
        {
            return Get($"{SELECT_ALL}WHERE Title LIKE @lecture_title", new { lecture_title = $"%{titleSubstring}%" });
        }

        public IQueryable<ILectureEntity> GetByDepartmentId (int departmentId)
        {
            return Get(GET_BY_DEPARTMENT_ID, new { department_id = departmentId });
        }

        public ILectureEntity GetById (int id)
        {
            Lecture lecture;
            using (var reader = GetMultiple(GET_BY_ID, new { lecture_id = id }))
            {
                lecture = reader.Read<Lecture>( ).Single();
                lecture.Students = reader.Read<Student>( ).ToList( );
                lecture.Departments = reader.Read<Department>( ).ToList( );
            }

            return lecture;
        }

        public IQueryable<ILectureEntity> GetByStudentId (int studentId)
        {
            return Get(GET_BY_STUDENT_ID, new { student_id = studentId });
        }

        public void Remove (ILectureEntity entity)
        {
            Execute(REMOVE_BY_ID, new { lecture_id = entity.Id }, CommandType.Text);
        }
    }
}
