using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDaora.Data;
using ProjetoDaora.Models;

namespace ProjetoDaora.Controllers
{
    public class ItemVendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemVendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemVendas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemVendas.Include(i => i.Produto).Include(i => i.Venda);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemVenda = await _context.ItemVendas
                .Include(i => i.Produto)
                .Include(i => i.Venda)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemVenda == null)
            {
                return NotFound();
            }

            return View(itemVenda);
        }

        // GET: ItemVendas/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId");
            return View();
        }

        // POST: ItemVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,VendaId,ProdutoId,Quantidade,PrecoUnitario,TotalItem")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", itemVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId", itemVenda.VendaId);
            return View(itemVenda);
        }

        // GET: ItemVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemVenda = await _context.ItemVendas.FindAsync(id);
            if (itemVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", itemVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId", itemVenda.VendaId);
            return View(itemVenda);
        }

        // POST: ItemVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,VendaId,ProdutoId,Quantidade,PrecoUnitario,TotalItem")] ItemVenda itemVenda)
        {
            if (id != itemVenda.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemVendaExists(itemVenda.ItemId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", itemVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId", itemVenda.VendaId);
            return View(itemVenda);
        }

        // GET: ItemVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemVenda = await _context.ItemVendas
                .Include(i => i.Produto)
                .Include(i => i.Venda)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemVenda == null)
            {
                return NotFound();
            }

            return View(itemVenda);
        }

        // POST: ItemVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemVenda = await _context.ItemVendas.FindAsync(id);
            if (itemVenda != null)
            {
                _context.ItemVendas.Remove(itemVenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemVendaExists(int id)
        {
            return _context.ItemVendas.Any(e => e.ItemId == id);
        }
    }
}
