using Way2Commerce.Domain.Entidades;

namespace Way2Commerce.Domain.Repositorios 
{
    public interface IProdutoRepositorio 
    {
        Task<IList<Produto>> BuscarTodos();
        Task<Produto> BuscarPorId(int produtoId);
        Task<int> Salvar(Produto produto);
        Task Alterar(Produto produto);
        Task Excluir(Produto produto);
    }
}