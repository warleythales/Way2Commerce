namespace Way2Commerce.Domain.Entidades
{
    public class ProdutoCategoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}