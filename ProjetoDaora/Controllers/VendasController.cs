using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDaora.Data;
using ProjetoDaora.Models;

namespace ProjetoDaora.Controllers
{
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vendas.Include(v => v.Vendedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var venda = await _context.Vendas
                .Include(v => v.Vendedor)
                .Include(v => v.Itens)
                .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            if (venda == null)
                return NotFound();

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome");
                ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
                return View(venda);
            }

            // Calcula o valor total baseado nos itens
            venda.ValorTotal = venda.Itens.Sum(i => i.Quantidade * i.PrecoUnitario);

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            // Atualiza o estoque após salvar a venda e itens
            foreach (var item in venda.Itens)
            {
                var produto = await _context.Produtos.FindAsync(item.ProdutoId);

                if (produto == null)
                    continue;

                if (produto.Estoque < item.Quantidade)
                {
                    ModelState.AddModelError("", $"Estoque insuficiente para o produto {produto.Nome}.");

                    // desfaz a venda
                    _context.Vendas.Remove(venda);
                    await _context.SaveChangesAsync();

                    ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome");
                    ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
                    return View(venda);
                }

                produto.Estoque -= item.Quantidade;
                _context.Produtos.Update(produto);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
                return NotFound();

            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome", venda.VendedorId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Venda venda)
        {
            if (id != venda.VendaId)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "Nome", venda.VendedorId);
                return View(venda);
            }

            try
            {
                _context.Update(venda);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vendas.Any(e => e.VendaId == venda.VendaId))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var venda = await _context.Vendas
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            if (venda == null)
                return NotFound();

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);

            if (venda != null)
                _context.Vendas.Remove(venda);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
