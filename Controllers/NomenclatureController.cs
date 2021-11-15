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
    public class NomenclatureController : ControllerBase
    {
        private readonly StorageContext _context;

        public NomenclatureController(StorageContext context)
        {
            _context = context;
        }

        // GET: api/NomenclatureModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NomenclatureModel>>> GetNomenclature()
        {
            return await _context.Nomenclature.ToListAsync();
        }

        // GET: api/NomenclatureModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NomenclatureModel>> GetNomenclatureModel(long id)
        {
            var nomenclatureModel = await _context.Nomenclature.FindAsync(id);

            if (nomenclatureModel == null)
            {
                return NotFound();
            }

            return nomenclatureModel;
        }

        // PUT: api/NomenclatureModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomenclatureModel(long id, NomenclatureModel nomenclatureModel)
        {
            if (id != nomenclatureModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(nomenclatureModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomenclatureModelExists(id))
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

        // POST: api/NomenclatureModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NomenclatureModel>> PostNomenclatureModel(NomenclatureModel nomenclatureModel)
        {
            _context.Nomenclature.Add(nomenclatureModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomenclatureModel", new { id = nomenclatureModel.Id }, nomenclatureModel);
        }

        // DELETE: api/NomenclatureModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomenclatureModel(long id)
        {
            var nomenclatureModel = await _context.Nomenclature.FindAsync(id);
            if (nomenclatureModel == null)
            {
                return NotFound();
            }

            _context.Nomenclature.Remove(nomenclatureModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NomenclatureModelExists(long id)
        {
            return _context.Nomenclature.Any(e => e.Id == id);
        }
    }
}
