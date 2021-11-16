using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageWebAPP.Models;

namespace StorageWebAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementTypeController : ControllerBase
    {
        private readonly StorageContext _context;

        public MovementTypeController(StorageContext context)
        {
            _context = context;
        }

        // GET: api/MovementType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementTypeModel>>> GetMovementType()
        {
            return await _context.MovementType.ToListAsync();
        }

        // GET: api/MovementType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovementTypeModel>> GetMovementTypeModel(long id)
        {
            var movementTypeModel = await _context.MovementType.FindAsync(id);

            if (movementTypeModel == null)
            {
                return NotFound();
            }

            return movementTypeModel;
        }

        // PUT: api/MovementType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovementTypeModel(long id, MovementTypeModel movementTypeModel)
        {
            if (id != movementTypeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(movementTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementTypeModelExists(id))
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

        // POST: api/MovementType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovementTypeModel>> PostMovementTypeModel(MovementTypeModel movementTypeModel)
        {
            _context.MovementType.Add(movementTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovementTypeModel", new { id = movementTypeModel.Id }, movementTypeModel);
        }

        // DELETE: api/MovementType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovementTypeModel(long id)
        {
            var movementTypeModel = await _context.MovementType.FindAsync(id);
            if (movementTypeModel == null)
            {
                return NotFound();
            }

            _context.MovementType.Remove(movementTypeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovementTypeModelExists(long id)
        {
            return _context.MovementType.Any(e => e.Id == id);
        }
    }
}
