using Microsoft.EntityFrameworkCore;
using Way2Commerce.Domain.Entidades;
using Way2Commerce.Domain.Repositorios;

namespace Way2Commerce.Data.Repositorios 
{
    public class ProdutoRepositorio : IProdutoRepositorio 
    {
        private readonly Way2CommerceContexto _dbContexto;
        public ProdutoRepositorio(Way2CommerceContexto dbContexto) 
        {
            _dbContexto = dbContexto;
        }

        public async Task<IList<Produto>> BuscarTodos()
            => await _dbContexto.Produtos.ToListAsync();

        public async Task<Produto> BuscarPorId(int produtoId) 
            => await _dbContexto.Produtos.FindAsync(produtoId);
        

        public async Task<int> Salvar(Produto produto) 
        {
            await _dbContexto.AddAsync(produto);
            await _dbContexto.SaveChangesAsync();
            return produto.Id;
        }

        public async Task Alterar(Produto produto) 
        {
            _dbContexto.Produtos.Update(produto);
            await _dbContexto.SaveChangesAsync();
        }

        public async Task Excluir(Produto produto) 
        {            
            _dbContexto.Produtos.Remove(produto);
            await _dbContexto.SaveChangesAsync();
        }
    }
}
