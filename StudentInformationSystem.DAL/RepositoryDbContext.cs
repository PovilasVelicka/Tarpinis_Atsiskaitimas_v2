using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DAL.Models;
namespace StudentInformationSystem.DAL
{
    internal class RepositoryDbContext : DbContext
    {
        private readonly bool _inMemory = false;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;

        public RepositoryDbContext ( )
        {
            _inMemory = false;
        }

        public RepositoryDbContext (bool inTestMode)
        {
            _inMemory = inTestMode;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (_inMemory)
                optionsBuilder.UseInMemoryDatabase("StudentsInfoSystem-prod");
            else
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=StudentsInfoSystem-prod;Trusted_Connection=True;");

        }
    }
}
