using BootcampAPIWithDB.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampAPIWithDB.Repository
{
    public interface IStudentRepository
    {
        bool Insert(StudentEntity entity);
    }
}
