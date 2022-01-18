using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositorioFilmes.Models;

namespace RepositorioFilmes.Controllers
{
    public class RepositoriosController : Controller
    {
        private readonly Context _context;

        public RepositoriosController(Context context)
        {
            _context = context;
        }

        // GET: Repositorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repositorio.ToListAsync());
        }

        // GET: Repositorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repositorio = await _context.Repositorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repositorio == null)
            {
                return NotFound();
            }

            return View(repositorio);
        }

        // GET: Repositorios/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Repositorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imagem,Nome,Descricao,Duracao,Genero,DataLancamento,Estilo")] Repositorio repositorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repositorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repositorio);
        }

        // GET: Repositorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repositorio = await _context.Repositorio.FindAsync(id);
            if (repositorio == null)
            {
                return NotFound();
            }
            return View(repositorio);
        }

        // POST: Repositorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagem,Nome,Descricao,Duracao,Genero,DataLancamento,Estilo")] Repositorio repositorio)
        {
            if (id != repositorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repositorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepositorioExists(repositorio.Id))
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
            return View(repositorio);
        }

        // GET: Repositorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repositorio = await _context.Repositorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repositorio == null)
            {
                return NotFound();
            }

            return View(repositorio);
        }

        // POST: Repositorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repositorio = await _context.Repositorio.FindAsync(id);
            _context.Repositorio.Remove(repositorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepositorioExists(int id)
        {
            return _context.Repositorio.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Repositorio.ToListAsync());
        }

        public async Task<IActionResult> Item(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repositorio = await _context.Repositorio.FindAsync(id);
            if (repositorio == null)
            {
                return NotFound();
            }
            return View(repositorio);
        }
    }
}
