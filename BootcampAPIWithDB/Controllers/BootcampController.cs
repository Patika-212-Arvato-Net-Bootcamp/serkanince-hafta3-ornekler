using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BootcampAPIWithDB.Data;
using BootcampAPIWithDB.Data.Entity;
using BootcampAPIWithDB.Data.Redis;
using Microsoft.AspNetCore.Authorization;

namespace BootcampAPIWithDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BootcampController : ControllerBase
    {
        private readonly BootcampContext _context;
        private readonly IRedisHelper redisHelper;

        public BootcampController(BootcampContext context, IRedisHelper redisHelper)
        {
            _context = context;
            this.redisHelper = redisHelper;
        }

        // GET: api/Bootcamp
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BootcampEntity>>> GetBootcamps()
        {
            if (_context.Bootcamps == null)
            {
                return NotFound();
            }
            return await _context.Bootcamps.ToListAsync();
        }

        // GET: api/Bootcamp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BootcampEntity>> GetBootcampEntity(int id)
        {
            if (_context.Bootcamps == null)
            {
                return NotFound();
            }
            var bootcampEntity = await _context.Bootcamps.FindAsync(id);

            if (bootcampEntity == null)
            {
                return NotFound();
            }


            var lastbootcampid = await redisHelper.GetKeyAsync("lastbootcampid");


            return bootcampEntity;
        }

        // PUT: api/Bootcamp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBootcampEntity(int id, BootcampEntity bootcampEntity)
        {
            if (id != bootcampEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(bootcampEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BootcampEntityExists(id))
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

        // POST: api/Bootcamp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<BootcampEntity>> PostBootcampEntity(BootcampEntity bootcampEntity)
        {
            if (_context.Bootcamps == null)
            {
                return Problem("Entity set 'BootcampContext.Bootcamps'  is null.");
            }


            _context.Bootcamps.Add(bootcampEntity);
            var bootcampId = await _context.SaveChangesAsync();


            await redisHelper.SetKeyAsync("lastbootcampid", bootcampEntity.Id.ToString());



            return CreatedAtAction("GetBootcampEntity", new { id = bootcampEntity.Id }, bootcampEntity);
        }

        // DELETE: api/Bootcamp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBootcampEntity(int id)
        {
            if (_context.Bootcamps == null)
            {
                return NotFound();
            }
            var bootcampEntity = await _context.Bootcamps.FindAsync(id);
            if (bootcampEntity == null)
            {
                return NotFound();
            }

            _context.Bootcamps.Remove(bootcampEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BootcampEntityExists(int id)
        {
            return (_context.Bootcamps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
