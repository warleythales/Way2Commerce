using Microsoft.AspNetCore.Mvc;
using Way2Commerce.Domain.Entidades;
using Way2Commerce.Domain.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Way2Commerce.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase 
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio) 
        {
            _produtoRepositorio = produtoRepositorio;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try 
            {
                var produtos = await _produtoRepositorio.BuscarTodos();
                return Ok(produtos);
            }
            catch (Exception) 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{produtoId}")]
        public async Task<IActionResult> Get(int produtoId) 
        {
            try 
            {
                var produto = await _produtoRepositorio.BuscarPorId(produtoId);
                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }            
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string codigo, [FromBody] string nome, [FromBody] string descricao, [FromBody] decimal preco, [FromBody] DateTime dataCadastro, [FromBody] int categoriaId) 
        {
            try 
            {
                var produto = new Produto {
                    Codigo = codigo,
                    Nome = nome,
                    Descricao = descricao,
                    Preco = preco,
                    DataHoraCadastro = dataCadastro,
                    CategoriaId = categoriaId
                };

                return Ok(await _produtoRepositorio.Salvar(produto));
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public async Task<IActionResult> Put(int produtoId, [FromBody] string codigo, [FromBody] string nome, [FromBody] string descricao, [FromBody] decimal preco, [FromBody] DateTime dataCadastro, [FromBody] int categoriaId) 
        {
            try 
            {
                var produto = await _produtoRepositorio.BuscarPorId(produtoId);
                if (produto == null)
                    return NotFound();

                produto.Codigo = codigo;
                produto.Nome = nome;
                produto.Descricao = descricao;
                produto.Preco = preco;
                produto.DataHoraCadastro = dataCadastro;
                produto.CategoriaId = categoriaId;                

                await _produtoRepositorio.Alterar(produto);

                return Ok();
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> Delete(int produtoId) 
        {
            try 
            {
                var produto = await _produtoRepositorio.BuscarPorId(produtoId);
                if (produto == null)
                    return NotFound();

                await _produtoRepositorio.Excluir(produto);

                return Ok();
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
    }
}
