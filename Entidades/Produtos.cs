
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Storage.Entidades
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        [Display(Name = "Quantidade em Estoque")]
        public int QuantidadeEstoque { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; } = 0;
        [Display(Name = "Categoria")]
        public Categoria categoria { get; set; }

    }
}
