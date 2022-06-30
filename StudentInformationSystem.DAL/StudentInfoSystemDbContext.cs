using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DAL.Models;

namespace StudentInformationSystem.DAL
{
    internal class StudentInfoSystemDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=StudentInfoSystem;Trusted_Connection=True;");

        }

    }
}
