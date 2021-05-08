using System;
using System.Linq;
using System.Threading.Tasks;
using SupZezinho.Application.contratos;
using SupZezinho.Domain.models;
using SupZezinho.Repository;

namespace SupZezinho.Application
{
    public class ProdutoService : IProdutoServices
    {
        private readonly IGeralRepository _geralrepository;
        private readonly IProdutosRepositry _produtoRepository;
        public ProdutoService(IGeralRepository geralrepository, IProdutosRepositry produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _geralrepository = geralrepository;

        }
        public async Task<Produto> AdicionarProduto(Produto model)
        {
            try
            {
               _geralrepository.Adicionar<Produto>(model);
                if (!await _geralrepository.SalvaAlteracoesAsync())
                    return null;
                else
                    return await _produtoRepository.BuscarProdutoPorIdAsync(model.Id);
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeletarProduto(int produtoId)
        {
            try
            {
              var produto = await _produtoRepository.BuscarProdutoPorIdAsync(produtoId);
              if(produto == null) throw new Exception("Produto não encontrado!");
              _geralrepository.Deletar<Produto>(produto);
              return await _geralrepository.SalvaAlteracoesAsync();
          
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Produto> AtualizarProduto(int produtoId, Produto model)
        {
            try
            {
              var produto = await _produtoRepository.BuscarProdutoPorIdAsync(produtoId);
              if(produto == null) return null;
              model.Id = produto.Id;
              _geralrepository.Atualizar(model);
              if (!await _geralrepository.SalvaAlteracoesAsync())
                    return null;
                else
                    return await _produtoRepository.BuscarProdutoPorIdAsync(model.Id);
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<Produto> BuscarProdutoPorIdAsync(int Id)
        {
            try 
            {
                var produto = await _produtoRepository.BuscarProdutoPorIdAsync(Id);
                if(produto == null) throw new Exception("Produto não encontrado!");
                return produto;
            }
             catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public IQueryable<Produto> BuscarProdutosPorFiltroAsync()
        {
            try 
            {
                var produtos = _produtoRepository.BuscarProdutosPorFiltroAsync();
                if(produtos == null) return null;
                return produtos;
            }
             catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
    }
}