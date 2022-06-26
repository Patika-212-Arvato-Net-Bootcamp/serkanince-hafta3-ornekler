using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BootcampAPIWithDB.Data;
using BootcampAPIWithDB.Data.Entity;
using BootcampAPIWithDB.Data.Dto;
using BootcampAPIWithDB.Repository;

namespace BootcampAPIWithDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly BootcampContext _context;
        private readonly IStudentRepository studentRepo;

        public StudentController(BootcampContext context, IStudentRepository studentRepo)
        {
            _context = context;
            this.studentRepo = studentRepo;
        }

        // GET: api/StudentEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEntity>>> GetStudents()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _context.Students.ToListAsync();
        }

        // GET: api/StudentEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEntity>> GetStudentEntity(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var studentEntity = await _context.Students.FindAsync(id);

            if (studentEntity == null)
            {
                return NotFound();
            }

            return studentEntity;
        }

        // PUT: api/StudentEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentEntity(int id, StudentEntity studentEntity)
        {
            if (id != studentEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDto>> PostStudentEntity(StudentsDto studentDto)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'BootcampContext.Students'  is null.");
            }
            //var entity = await _context.Students.AddAsync(new StudentEntity()
            //{
            //    Name = studentDto.Name,
            //    Age = studentDto.Age,
            //    Surname = studentDto.Surname,
            //    BootcampId = studentDto.BootcampId
            //});

            studentRepo.Insert(new StudentEntity()
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                Surname = studentDto.Surname,
                BootcampId = studentDto.BootcampId
            });


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentEntity", new { id = 1 }, studentDto);
        }

        // DELETE: api/StudentEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentEntity(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var studentEntity = await _context.Students.FindAsync(id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentEntityExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
