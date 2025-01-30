using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaA.Models;

namespace PruebaA.Controllers
{
    public class AutoresController : Controller
    {

        private readonly SysDbcontext _context;
        public AutoresController(SysDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var autores = await _context.Autores.ToListAsync();
            return View(autores); 
        }

        public async Task<IActionResult> Details(int id, Autores autor)
        {
            var autores = await _context.Autores.FindAsync(id);
            return View(autores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autores autor)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(autor); 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            return View(autor); 
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var autor = await _context.Autores.FindAsync(id);
            return View(autor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Autores autor)
        {

            if (!ModelState.IsValid)
            {
                 _context.Update(autor); 
                    await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); 
            }
            return View(autor);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var autor = await _context.Autores
                .FirstOrDefaultAsync(m => m.id == id);
            return View(autor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            _context.Autores.Remove(autor); 
            await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index)); 
        }

    }

}
