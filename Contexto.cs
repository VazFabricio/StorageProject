using Microsoft.EntityFrameworkCore;
using Storage.Entidades;

namespace Storage
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options ) : base(options)
        { 

        }

        public DbSet<Produtos> PRODUTOS { get; set; }

    }
}
