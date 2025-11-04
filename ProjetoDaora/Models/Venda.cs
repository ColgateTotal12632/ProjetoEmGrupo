using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDaora.Models
{
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "É necessário informar o vendedor.")]
        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }

        public Vendedor? Vendedor { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O valor total é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O valor total deve ser maior que zero.")]
        public decimal ValorTotal { get; set; }

        public ICollection<ItemVenda>? Itens { get; set; }
    }
}