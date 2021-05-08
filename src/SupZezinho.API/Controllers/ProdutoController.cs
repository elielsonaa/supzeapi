using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupZezinho.Application.contratos;
using SupZezinho.Domain.models;
using SupZezinho.Repository;

namespace SupZezinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServices _produtoServices;
        public ProdutoController(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
  
        }
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Produto> GetByFilter()
        {
            try
            {
              var produtos =  _produtoServices.BuscarProdutosPorFiltroAsync();
              if(produtos == null) throw new Exception("Não foi encontrado produtos com os critérios informados!");
              return produtos.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($" Erro ao filtrar produtos. Erro:{ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try         
            {
              var produto = await _produtoServices.BuscarProdutoPorIdAsync(id);
              if(produto == null)return NotFound($"Não foi encntrar o produto com o Id: {id}");
              return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar produto. Erro:{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Produto model)
        {
            try         
            {
              var produto = await _produtoServices.AdicionarProduto(model);
              if(produto == null) return BadRequest("Erro ao cadastrar produto.");
              return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao cadastrar produto. Erro:{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , Produto model)
        {
            try         
            {
              var produto = await _produtoServices.AtualizarProduto(id,model);
              if(produto == null) return BadRequest("Erro ao atualizar produto.");
              return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao atualizar produto. Erro:{ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try         
            {
                   return await _produtoServices.DeletarProduto(id) ? 
                                Ok("Produto deletado") :
                                BadRequest("Não foi possivel deletar o produto!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao deletar produto. Erro:{ex.Message}");
            }
        }
    }
}