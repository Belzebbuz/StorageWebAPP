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
    public class BalanceController : ControllerBase
    {
        private readonly StorageContext _context;

        public BalanceController(StorageContext context)
        {
            _context = context;
        }

        // GET: api/BalanceModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceModel>>> GetBalance()
        {
            return await _context.Balance.ToListAsync();
        }

        // GET: api/BalanceModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BalanceModel>> GetBalanceModel(long id)
        {
            var balanceModel = await _context.Balance.FindAsync(id);

            if (balanceModel == null)
            {
                return NotFound();
            }

            return balanceModel;
        }

        // PUT: api/BalanceModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalanceModel(long id, BalanceModel balanceModel)
        {
            if (id != balanceModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(balanceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceModelExists(id))
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

        // POST: api/BalanceModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BalanceModel>> PostBalanceModel(BalanceModel balanceModel)
        {
            _context.Balance.Add(balanceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalanceModel", new { id = balanceModel.Id }, balanceModel);
        }

        // DELETE: api/BalanceModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBalanceModel(long id)
        {
            var balanceModel = await _context.Balance.FindAsync(id);
            if (balanceModel == null)
            {
                return NotFound();
            }

            _context.Balance.Remove(balanceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BalanceModelExists(long id)
        {
            return _context.Balance.Any(e => e.Id == id);
        }
    }
}
