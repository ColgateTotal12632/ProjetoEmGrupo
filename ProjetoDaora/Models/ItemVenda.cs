using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDaora.Models
{
    public class ItemVenda
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("Venda")]
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Required(ErrorMessage = "Informe a quantidade vendida.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o preço unitário.")]
        [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }

        [NotMapped]
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }
}