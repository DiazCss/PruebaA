using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaA.Models;

namespace PruebaA.Controllers
{
    public class LibrosController : Controller
    {

        private readonly SysDbcontext _context;
        public LibrosController(SysDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var libro = _context.Libros.Include(l => l.autores).ToList();
            var libros = await _context.Libros.ToListAsync();
            return View(libros);
        }

        public async Task<IActionResult> Details(int id, Libros libros)
        {
            var libro = await _context.Libros.FindAsync(id);
            return View(libro);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var autores = _context.Autores.ToList();

            if (autores == null || autores.Count == 0)
            {
                ViewBag.Autores = new SelectList(new List<Autores>(), "Id", "Nombre");
            }
            else
            {
                ViewBag.Autores = new SelectList(autores, "id", "Nombre");
            }

            return View(new Libros());  // <-- IMPORTANTE: Asegurar que el modelo no sea null
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libros libros)
        {
            if (!ModelState.IsValid) 
            {
                _context.Add(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var autores = await _context.Autores.ToListAsync();
            ViewBag.Autores = new SelectList(autores, "AutorId", "Nombre");
            return View(libros);
        }

        public ActionResult Edit(int id, Libros libros)

        {
            var autores = _context.Autores.ToList();

            if (autores == null || autores.Count == 0)
            {
                ViewBag.Autores = new SelectList(new List<Autores>(), "Id", "Nombre");
            }
            else
            {
                ViewBag.Autores = new SelectList(autores, "id", "Nombre");
            }
            var libro = _context.Libros.Find(id);
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Libros libros)
        {
            if (!ModelState.IsValid)
            {
                _context.Update(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var autores = await _context.Autores.ToListAsync();
            ViewBag.Autores = new SelectList(autores, "AutorId", "Nombre");
            return View(libros);
        }


        public ActionResult Delete(int id) 
        {
            //var autores = _context.Autores.ToList();

            //if (autores == null || autores.Count == 0)
            //{
            //    ViewBag.Autores = new SelectList(new List<Autores>(), "Id", "Nombre");
            //}
            //else
            //{
            //    ViewBag.Autores = new SelectList(autores, "id", "Nombre");
            //}

            var libro =  _context.Libros.Find(id);
            return View(libro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Libros libros)
        {
            if(!ModelState.IsValid)
            {
                _context.Libros.Remove(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libros);
        }
    }
}
