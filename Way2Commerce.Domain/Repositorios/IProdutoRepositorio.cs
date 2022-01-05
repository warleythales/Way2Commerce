using Way2Commerce.Domain.Entidades;

namespace Way2Commerce.Domain.Repositorios
{
    public interface IProdutoRepositorio
    {
        IList<Produto> BuscarTodos();        
        int Salvar(Produto produto);
        void Alterar(Produto produto);
        void Excluir(int ProdutoId);
    }
}