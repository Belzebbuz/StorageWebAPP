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
    public class AccountsController : ControllerBase
    {
        private readonly StorageContext _context;

        public AccountsController(StorageContext context)
        {
            _context = context;
        }

        // GET: api/AccountModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountModel>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/AccountModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountModel>> GetAccountModel(long id)
        {
            var accountModel = await _context.Accounts.FindAsync(id);

            if (accountModel == null)
            {
                return NotFound();
            }

            return accountModel;
        }

        // PUT: api/AccountModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountModel(long id, AccountModel accountModel)
        {
            if (id != accountModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountModelExists(id))
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

        // POST: api/AccountModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountModel>> PostAccountModel(AccountModel accountModel)
        {
            _context.Accounts.Add(accountModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountModel", new { id = accountModel.Id }, accountModel);
        }

        // DELETE: api/AccountModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountModel(long id)
        {
            var accountModel = await _context.Accounts.FindAsync(id);
            if (accountModel == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(accountModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountModelExists(long id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
