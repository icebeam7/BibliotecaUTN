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
    public class PrestamosController : Controller
    {
        private readonly BibliotecaContext _context;

        public PrestamosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Prestamos.Include(p => p.FK_AlumnoPrestamo).Include(p => p.FK_LibroPrestamo).Include(p => p.FK_StatusPrestamo);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.FK_AlumnoPrestamo)
                .Include(p => p.FK_LibroPrestamo)
                .Include(p => p.FK_StatusPrestamo)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro");
            ViewData["IdStatusPrestamo"] = new SelectList(_context.StatusPrestamos, "IdStatusPrestamo", "IdStatusPrestamo");
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,IdLibro,IdAlumno,Codigo,FechaPrestamo,FechaLimite,FechaDevolucion,IdStatusPrestamo,MontoMulta")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                prestamo.IdPrestamo = Guid.NewGuid();
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", prestamo.IdAlumno);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", prestamo.IdLibro);
            ViewData["IdStatusPrestamo"] = new SelectList(_context.StatusPrestamos, "IdStatusPrestamo", "IdStatusPrestamo", prestamo.IdStatusPrestamo);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", prestamo.IdAlumno);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", prestamo.IdLibro);
            ViewData["IdStatusPrestamo"] = new SelectList(_context.StatusPrestamos, "IdStatusPrestamo", "IdStatusPrestamo", prestamo.IdStatusPrestamo);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPrestamo,IdLibro,IdAlumno,Codigo,FechaPrestamo,FechaLimite,FechaDevolucion,IdStatusPrestamo,MontoMulta")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", prestamo.IdAlumno);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", prestamo.IdLibro);
            ViewData["IdStatusPrestamo"] = new SelectList(_context.StatusPrestamos, "IdStatusPrestamo", "IdStatusPrestamo", prestamo.IdStatusPrestamo);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.FK_AlumnoPrestamo)
                .Include(p => p.FK_LibroPrestamo)
                .Include(p => p.FK_StatusPrestamo)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(Guid id)
        {
            return _context.Prestamos.Any(e => e.IdPrestamo == id);
        }
    }
}
