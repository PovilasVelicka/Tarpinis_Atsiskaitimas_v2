using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.BLL.Models
{
    public interface IDepartmentDto
    {
        public int Id { get; }
        public string Name { get; set; }
        public string  City { get; set; }
    }
}
