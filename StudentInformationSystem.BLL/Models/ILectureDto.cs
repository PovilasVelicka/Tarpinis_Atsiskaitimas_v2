using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.BLL.Models
{
    public interface ILectureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
