using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DAL.Models;
using System.Diagnostics;
namespace StudentInformationSystem.DAL
{
    internal class RepositoryDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=StudentInfoSystem;Trusted_Connection=True;");
            //optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

    }
}
