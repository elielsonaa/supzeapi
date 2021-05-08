using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorServices _fornecedoresServices;
        public FornecedorController(IFornecedorServices fornecedoresServices)
        {
            _fornecedoresServices = fornecedoresServices;
  
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
              var fornecedores = await _fornecedoresServices.BuscarFornecedoresAsync();
              if(fornecedores == null)return NotFound("Nenhum fornecedor encontrado.");
              return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar fornecedor. Erro:{ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try         
            {
              var fornecedor = await _fornecedoresServices.BuscarFornecedorPorIdAsync(id);
              if(fornecedor == null)return NotFound($"Não foi encontrado fornecedor com o Id: {id}");
              return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar fornecedor. Erro:{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Fornecedor model)
        {
            try         
            {
              var fornecedor = await _fornecedoresServices.AdicionarFornecedor(model);
              if(fornecedor == null) return BadRequest("Erro ao cadastrar fornecedor.");
              return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao cadastrar fornecedor. Erro:{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , Fornecedor model)
        {
            try         
            {
              var fornecedor = await _fornecedoresServices.AtualizarFornecedor(id,model);
              if(fornecedor == null) return BadRequest("Erro ao atualizar fornecedor.");
              return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao atualizar fornecedor. Erro:{ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try         
            {
                   return await _fornecedoresServices.DeletarFornecedor(id) ? 
                                Ok("Fornecedor deletado") :
                                BadRequest("Não foi possivel deletar o fornecedor!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao deletar fornecedor. Erro:{ex.Message}");
            }
        }
    }
}