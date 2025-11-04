using System;

namespace ProjetoDaora.Models
{
    public class ResumoVendasDia
    {
        public DateTime Data { get; set; } = DateTime.Today;
        public int TotalVendas { get; set; }
        public decimal ValorTotalVendas { get; set; }
        public int TotalItensVendidos { get; set; }
    }
}