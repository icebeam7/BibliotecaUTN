using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaUTN.Context;
using BibliotecaUTN.Models;

namespace BibliotecaUTN.Controllers
{
    public class LibrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Libros.Include(l => l.FK_EditorialLibro).Include(l => l.FK_GeneroLibro).Include(l => l.FK_PaisLibro);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.FK_EditorialLibro)
                .Include(l => l.FK_GeneroLibro)
                .Include(l => l.FK_PaisLibro)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["IdEditorial"] = new SelectList(_context.Editoriales, "IdEditorial", "Nombre");
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre");
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,ISBN,Titulo,IdEditorial,IdGenero,IdPais,Año,Imagen")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.IdLibro = Guid.NewGuid();
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEditorial"] = new SelectList(_context.Editoriales, "IdEditorial", "Nombre", libro.IdEditorial);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", libro.IdGenero);
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "Nombre", libro.IdPais);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IdEditorial"] = new SelectList(_context.Editoriales, "IdEditorial", "Nombre", libro.IdEditorial);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", libro.IdGenero);
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "Nombre", libro.IdPais);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdLibro,ISBN,Titulo,IdEditorial,IdGenero,IdPais,Año,Imagen")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            ViewData["IdEditorial"] = new SelectList(_context.Editoriales, "IdEditorial", "Nombre", libro.IdEditorial);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", libro.IdGenero);
            ViewData["IdPais"] = new SelectList(_context.Paises, "IdPais", "Nombre", libro.IdPais);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.FK_EditorialLibro)
                .Include(l => l.FK_GeneroLibro)
                .Include(l => l.FK_PaisLibro)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(Guid id)
        {
            return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
