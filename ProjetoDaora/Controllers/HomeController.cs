using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoDaora.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoDaora.Data;

namespace ProjetoDaora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var resumo = new ResumoVendasDia
            {
                Data = DateTime.Today
            };

            var vendasDoDia = _context.Vendas
                .Include(v => v.Itens)
                .Where(v => v.DataVenda.Date == DateTime.Today)
                .ToList();

            resumo.TotalVendas = vendasDoDia.Count;
            resumo.ValorTotalVendas = vendasDoDia.Sum(v => v.ValorTotal);
            resumo.TotalItensVendidos = vendasDoDia.Sum(v => v.Itens.Sum(i => i.Quantidade));

            return View(resumo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}