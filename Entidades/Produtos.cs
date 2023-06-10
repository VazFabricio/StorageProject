
namespace Storage.Entidades
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; } = 0;
        public Categoria categoria { get; set; }

    }
}
