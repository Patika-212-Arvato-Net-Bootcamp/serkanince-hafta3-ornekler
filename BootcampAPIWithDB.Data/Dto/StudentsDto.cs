using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampAPIWithDB.Data.Dto
{
    public class StudentsDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int? BootcampId { get; set; }
    }
}
