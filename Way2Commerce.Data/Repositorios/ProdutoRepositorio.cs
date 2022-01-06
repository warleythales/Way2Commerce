using Way2Commerce.Domain.Entidades;
using Way2Commerce.Domain.Repositorios;

namespace Way2Commerce.Data.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private Way2CommerceContexto _dbContexto;
        public ProdutoRepositorio(Way2CommerceContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public void Alterar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(int ProdutoId)
        {
            throw new NotImplementedException();
        }

        public int Salvar(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
