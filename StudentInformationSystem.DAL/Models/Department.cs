﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CL.Interfaces;

namespace StudentInformationSystem.DAL.Models
{
    internal class Department : IDepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual List<IStudentEntity> Students { get; set; } = null!;
        public virtual List<ILectureEntity> Lecture { get; set; } = null!;
        private Department() { }

        public Department(string name, string city)
        {
            Name = name;
            City = city;
            Students = new List<IStudentEntity>();
            Lecture = new List<ILectureEntity>();
        }
    }
}
