using BootcampAPIWithDB.Data;
using BootcampAPIWithDB.Data.Dto;
using BootcampAPIWithDB.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPIWithDB.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly BootcampContext context;

        public StudentRepository(BootcampContext context)
        {
            this.context = context;
        }

        public bool Insert(StudentEntity entity)
        {

            //Method Syntax
            context.Students.Where(x => x.Id == 1).Include(x=> x.Bootcamp);
            context.Students.Where(x => x.Name == "serkan").ToList();
            context.Students.Count(x => x.Surname == "ince");
            context.Students.Sum(x => x.Age);
            context.Students.LastOrDefault();
            context.Students.OrderByDescending(x => x.Id).First();
            context.Students.Max(x => x.Age);
            context.Students.Min(x => x.Age);


            var studentList = context.Students.Where(x => x.Name == "serkan").Select(x => new StudentsDto()
            {
                Name = x.Name,
                Surname = x.Surname,
                Age = x.Age,
                BootcampId = x.BootcampId
            }).ToList();


            //Query Syntax
            var s = from students
                    in context.Students
                    select students.Name;


            context.Students.Add(entity);

            return true;
        }
    }
}
