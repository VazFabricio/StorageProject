using Storage.Entidades;

namespace Storage.Models
{
    public class ProdutosModel : Produtos
    {
        public List<Categoria> ListaCategorias { get; set; }   
    }
}
