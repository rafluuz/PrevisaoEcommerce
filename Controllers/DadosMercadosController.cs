using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrevisaoEcommerce.Models;
using PrevisaoEcommerce.Persistence;

namespace PrevisaoEcommerce.Controllers
{
    public class DadosMercadosController : Controller
    {
        private readonly SprintDbContext _context;

        public DadosMercadosController(SprintDbContext context)
        {
            _context = context;
        }

        // GET: DadosMercados
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadosMercados.ToListAsync());
        }

        // GET: DadosMercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosMercado = await _context.DadosMercados
                .FirstOrDefaultAsync(m => m.IdDadosMerc == id);
            if (dadosMercado == null)
            {
                return NotFound();
            }

            return View(dadosMercado);
        }

        // GET: DadosMercados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadosMercados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDadosMerc,NomeEmpresa,AnoPrevisao")] DadosMercado dadosMercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosMercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadosMercado);
        }

        // GET: DadosMercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosMercado = await _context.DadosMercados.FindAsync(id);
            if (dadosMercado == null)
            {
                return NotFound();
            }
            return View(dadosMercado);
        }

        // POST: DadosMercados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDadosMerc,NomeEmpresa,AnoPrevisao")] DadosMercado dadosMercado)
        {
            if (id != dadosMercado.IdDadosMerc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosMercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosMercadoExists(dadosMercado.IdDadosMerc))
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
            return View(dadosMercado);
        }

        // GET: DadosMercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosMercado = await _context.DadosMercados
                .FirstOrDefaultAsync(m => m.IdDadosMerc == id);
            if (dadosMercado == null)
            {
                return NotFound();
            }

            return View(dadosMercado);
        }

        // POST: DadosMercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosMercado = await _context.DadosMercados.FindAsync(id);
            if (dadosMercado != null)
            {
                _context.DadosMercados.Remove(dadosMercado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosMercadoExists(int id)
        {
            return _context.DadosMercados.Any(e => e.IdDadosMerc == id);
        }
    }
}
