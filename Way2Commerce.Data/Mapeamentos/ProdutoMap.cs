using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2Commerce.Domain.Entidades;

namespace Way2Commerce.Data.Mapeamentos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(6)")
                .IsRequired();
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();
            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(p => p.DataHoraCadastro)
                .HasColumnType("datetime")
                .IsRequired();
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
