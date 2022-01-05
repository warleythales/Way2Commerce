namespace Way2Commerce.Domain.Entidades
{
    public  class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaProduto Categoria { get; set; }
    }
}