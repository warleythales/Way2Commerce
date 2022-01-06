using Microsoft.EntityFrameworkCore;
using Way2Commerce.Data.Mapeamentos;
using Way2Commerce.Domain.Entidades;

namespace Way2Commerce.Data
{
    public class Way2CommerceContexto : DbContext
    {
        public Way2CommerceContexto(DbContextOptions<Way2CommerceContexto> options) : base (options) { }

        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder
                .UseSqlServer(@"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-CPEVJU9\wtsl_;Initial Catalog=way2Commerce;Data Source=DESKTOP-CPEVJU9");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoCategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}