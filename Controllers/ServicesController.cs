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
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index(string searchString, int? categoryId, int? employeeId, int? roomId, int? promotionId, int? clientGroupId, string sortOrder)
        {
            Console.WriteLine("Index action called.");

            //ViewData["CurrentSort"] = sortOrder;
            //ViewData["PriceSortParam"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            //ViewData["NameSortParam"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            var services = _context.services
                .Include(s => s.Category)
                .Include(s => s.Employee)
                .Include(s => s.RoomType)
                .Include(s => s.Promotion)
                .Include(s => s.ClientGroup)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.name.Contains(searchString));
            }
            if (categoryId != null)
            {
                services = services.Where(s => s.idCategory == categoryId);
            }
            if (employeeId != null)
            {
                services = services.Where(s => s.idEmployee == employeeId);
            }
            if (roomId != null)
            {
                services = services.Where(s => s.idRoom == roomId);
            }
            if (promotionId != null)
            {
                services = services.Where(s => s.idPromotion == promotionId);
            }
            if (clientGroupId != null)
            {
                services = services.Where(s => s.idClientGroup == clientGroupId);
            }

            switch (sortOrder)
            {
                case "price_asc":
                    services = services.OrderBy(s => s.price);
                    break;
                case "price_desc":
                    services = services.OrderByDescending(s => s.price);
                    break;
                case "name_asc":
                    services = services.OrderBy(s => s.name);
                    break;
                case "name_desc":
                    services = services.OrderByDescending(s => s.name);
                    break;
                default:
                    break;
            }
            var applicationDbContext = await services.ToListAsync();

            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "category", categoryId);
            ViewData["idEmployee"] = new SelectList(_context.employees, "idEmployee", "fullName", employeeId);
            ViewData["idRoom"] = new SelectList(_context.roomTypes, "idRoomType", "name", roomId);
            ViewData["idPromotion"] = new SelectList(_context.promotions, "idPromotion", "name", promotionId);
            ViewData["idClientGroup"] = new SelectList(_context.clientGroups, "idClientGroup", "name", clientGroupId);
            ViewData["searchString"] = searchString;

            return View(await services.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.services
                .Include(s => s.Category)
                .Include(s => s.Employee)
                .Include(s => s.RoomType)
                .Include(s => s.Promotion)
                .Include(s => s.ClientGroup)
                .FirstOrDefaultAsync(m => m.idService == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "name");
            ViewData["idEmployee"] = new SelectList(_context.employees, "idEmployee", "fullName");
            ViewData["idRoom"] = new SelectList(_context.roomTypes, "idRoom", "name");
            ViewData["idPromotion"] = new SelectList(_context.promotions, "idPromotion", "name");
            ViewData["idClientGroup"] = new SelectList(_context.clientGroups, "idClientGroup", "name");
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idService,name,description,price,idCategory,idEmployee,idRoom,idPromotion,duration,idClientGroup")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "name", service.idCategory);
            ViewData["idEmployee"] = new SelectList(_context.employees, "idEmployee", "fullName", service.idEmployee);
            ViewData["idRoom"] = new SelectList(_context.roomTypes, "idRoom", "name", service.idRoom);
            ViewData["idPromotion"] = new SelectList(_context.promotions, "idPromotion", "name", service.idPromotion);
            ViewData["idClientGroup"] = new SelectList(_context.clientGroups, "idClientGroup", "name", service.idClientGroup);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "name", service.idCategory);
            ViewData["idEmployee"] = new SelectList(_context.employees, "idEmployee", "fullName", service.idEmployee);
            ViewData["idRoom"] = new SelectList(_context.roomTypes, "idRoom", "name", service.idRoom);
            ViewData["idPromotion"] = new SelectList(_context.promotions, "idPromotion", "name", service.idPromotion);
            ViewData["idClientGroup"] = new SelectList(_context.clientGroups, "idClientGroup", "name", service.idClientGroup);
            return View(service);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idService,name,description,price,idCategory,idEmployee,idRoom,idPromotion,duration,idClientGroup")] Service service)
        {
            if (id != service.idService)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.idService))
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
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "name", service.idCategory);
            ViewData["idEmployee"] = new SelectList(_context.employees, "idEmployee", "fullName", service.idEmployee);
            ViewData["idRoom"] = new SelectList(_context.roomTypes, "idRoom", "name", service.idRoom);
            ViewData["idPromotion"] = new SelectList(_context.promotions, "idPromotion", "name", service.idPromotion);
            ViewData["idClientGroup"] = new SelectList(_context.clientGroups, "idClientGroup", "name", service.idClientGroup);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.services
                .Include(s => s.Category)
                .Include(s => s.Employee)
                .Include(s => s.RoomType)
                .Include(s => s.Promotion)
                .Include(s => s.ClientGroup)
                .FirstOrDefaultAsync(m => m.idService == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.services.FindAsync(id);
            if (service != null)
            {
                _context.services.Remove(service);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.services.Any(e => e.idService == id);
        }
    }
}