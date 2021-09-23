using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SD6503_DHl.Models;

namespace SD6503_DHl.Controllers
{
    public class AccountDetailsController : Controller
    {
        private readonly DhlDatabaseContext _context;

        public AccountDetailsController(DhlDatabaseContext context)
        {
            _context = context;
        }

        // GET: AccountDetails
        public async Task<IActionResult> Index()
        {
            var dhlDatabaseContext = _context.AccountDetails.Include(a => a.IdentifierNavigation);
            return View(await dhlDatabaseContext.ToListAsync());
        }

        // GET: AccountDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetail = await _context.AccountDetails
                .Include(a => a.IdentifierNavigation)
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (accountDetail == null)
            {
                return NotFound();
            }

            return View(accountDetail);
        }

        // GET: AccountDetails/Create
        public IActionResult Create()
        {
            ViewData["Identifier"] = new SelectList(_context.LoginAccounts, "Identifier", "Identifier");
            return View();
        }

        // POST: AccountDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identifier,AccountNumber,Name,Balance")] AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Identifier"] = new SelectList(_context.LoginAccounts, "Identifier", "Identifier", accountDetail.Identifier);
            return View(accountDetail);
        }

        // GET: AccountDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetail = await _context.AccountDetails.FindAsync(id);
            if (accountDetail == null)
            {
                return NotFound();
            }
            ViewData["Identifier"] = new SelectList(_context.LoginAccounts, "Identifier", "Identifier", accountDetail.Identifier);
            return View(accountDetail);
        }

        // POST: AccountDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Identifier,AccountNumber,Name,Balance")] AccountDetail accountDetail)
        {
            if (id != accountDetail.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountDetailExists(accountDetail.AccountNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Identifier"] = new SelectList(_context.LoginAccounts, "Identifier", "Identifier", accountDetail.Identifier);
            return View(accountDetail);
        }

        // GET: AccountDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetail = await _context.AccountDetails
                .Include(a => a.IdentifierNavigation)
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (accountDetail == null)
            {
                return NotFound();
            }

            return View(accountDetail);
        }

        // POST: AccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountDetail = await _context.AccountDetails.FindAsync(id);
            _context.AccountDetails.Remove(accountDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountDetailExists(string id)
        {
            return _context.AccountDetails.Any(e => e.AccountNumber == id);
        }
    }
}
