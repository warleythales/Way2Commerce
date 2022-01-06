using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2Commerce.Domain.Entidades;

namespace Way2Commerce.Data.Mapeamentos
{
    public class ProdutoCategoriaMap : IEntityTypeConfiguration<ProdutoCategoria>
    {
        public void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            builder.ToTable("ProdutoCategoria");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Id).ValueGeneratedOnAdd();
            builder.Property(pc => pc.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.HasData(new ProdutoCategoria { Nome = "Categoria 1" });
            builder.HasData(new ProdutoCategoria { Nome = "Categoria 2" });
        }
    }
}
