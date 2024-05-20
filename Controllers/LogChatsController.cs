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
    public class LogChatsController : Controller
    {
        private readonly SprintDbContext _context;

        public LogChatsController(SprintDbContext context)
        {
            _context = context;
        }

        // GET: LogChats
        public async Task<IActionResult> Index()
        {
            return View(await _context.LogChats.ToListAsync());
        }

        // GET: LogChats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logChat = await _context.LogChats
                .FirstOrDefaultAsync(m => m.IdLogChat == id);
            if (logChat == null)
            {
                return NotFound();
            }

            return View(logChat);
        }

        // GET: LogChats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogChats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLogChat,Mensagem,DataHora")] LogChat logChat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logChat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logChat);
        }

        // GET: LogChats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logChat = await _context.LogChats.FindAsync(id);
            if (logChat == null)
            {
                return NotFound();
            }
            return View(logChat);
        }

        // POST: LogChats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLogChat,Mensagem,DataHora")] LogChat logChat)
        {
            if (id != logChat.IdLogChat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logChat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogChatExists(logChat.IdLogChat))
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
            return View(logChat);
        }

        // GET: LogChats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logChat = await _context.LogChats
                .FirstOrDefaultAsync(m => m.IdLogChat == id);
            if (logChat == null)
            {
                return NotFound();
            }

            return View(logChat);
        }

        // POST: LogChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logChat = await _context.LogChats.FindAsync(id);
            if (logChat != null)
            {
                _context.LogChats.Remove(logChat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogChatExists(int id)
        {
            return _context.LogChats.Any(e => e.IdLogChat == id);
        }
    }
}
