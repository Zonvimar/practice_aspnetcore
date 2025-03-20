using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.clientGroups.ToListAsync());
        }

        // GET: ClientGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.clientGroups
                .FirstOrDefaultAsync(m => m.idClientGroup == id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // GET: ClientGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idClientGroup,name")] ClientGroup clientGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientGroup);
        }

        // GET: ClientGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.clientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }
            return View(clientGroup);
        }

        // POST: ClientGroups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idClientGroup,name")] ClientGroup clientGroup)
        {
            if (id != clientGroup.idClientGroup)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientGroupExists(clientGroup.idClientGroup))
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
            return View(clientGroup);
        }

        // GET: ClientGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.clientGroups
                .FirstOrDefaultAsync(m => m.idClientGroup == id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // POST: ClientGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientGroup = await _context.clientGroups.FindAsync(id);
            if (clientGroup != null)
            {
                _context.clientGroups.Remove(clientGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientGroupExists(int id)
        {
            return _context.clientGroups.Any(e => e.idClientGroup == id);
        }
    }
}