using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaUTN.Context;
using BibliotecaUTN.Models;

using X.PagedList;

namespace BibliotecaUTN.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly BibliotecaContext _context;

        public EditorialesController(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber, int? pageSize, string currentSort)
        {
            ViewBag.CurrentSort = sortOrder ?? currentSort;
            sortOrder = ViewBag.CurrentSort;

            if (string.IsNullOrEmpty(sortOrder))
                sortOrder = "nombre";

            ViewBag.SortNombre = ((sortOrder == "nombre") ? "nombre_desc" : "nombre");

            var currentPageSize = pageSize.HasValue ? pageSize.Value : 10;
            ViewBag.CurrentPageSize = currentPageSize;

            if (!string.IsNullOrWhiteSpace(searchString))
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var list = await _context.Editoriales.ToListAsync();

            var source = string.IsNullOrWhiteSpace(searchString)
                ? list
                : list.Where(x => x.Nombre.ToLower().Contains(searchString.ToLower()));

            switch (sortOrder)
            {
                case "nombre":
                    source = source.OrderBy(x => x.Nombre);
                    break;
                case "nombre_desc":
                    source = source.OrderByDescending(x => x.Nombre);
                    break;
            }

            var number = pageNumber ?? 1;
            return View(new Classes.ClasePagina<Editorial>() { Lista = source.ToPagedList(number, currentPageSize) });
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            var editorial = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.IdEditorial == id);

            if (editorial == null)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            return View(editorial);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEditorial,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                editorial.IdEditorial = Guid.NewGuid();
                _context.Add(editorial);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), 
                    new { ac = "Registro insertado con éxito", type = "success" });
            }

            return View(editorial);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            var editorial = await _context.Editoriales.FindAsync(id);
            if (editorial == null)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            return View(editorial);
        }

        // POST: Editoriales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEditorial,Nombre")] Editorial editorial)
        {
            if (id != editorial.IdEditorial)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialExists(editorial.IdEditorial))
                        return RedirectToAction(nameof(Index),
                            new { ac = "El registro no existe", type = "danger" });
                    else
                        return RedirectToAction(nameof(Index),
                            new { ac = "Error de concurrencia", type = "danger" });
                }
                return RedirectToAction(nameof(Index), new { ac = "Registro editado con éxito", type = "success" });
            }
            return View(editorial);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            var editorial = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.IdEditorial == id);
            if (editorial == null)
                return RedirectToAction(nameof(Index),
                    new { ac = "El registro no existe", type = "danger" });

            return View(editorial);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var editorial = await _context.Editoriales.FindAsync(id);
            _context.Editoriales.Remove(editorial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ac = "Registro eliminado con éxito", type = "success" });
        }

        private bool EditorialExists(Guid id)
        {
            return _context.Editoriales.Any(e => e.IdEditorial == id);
        }
    }
}
