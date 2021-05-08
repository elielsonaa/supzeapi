using System;
using System.Linq;
using System.Threading.Tasks;
using SupZezinho.Domain.models;

namespace SupZezinho.Application.contratos
{
    public interface IProdutoServices
    {
         Task<Produto> AdicionarProduto(Produto model);
         Task<Produto> AtualizarProduto(int produtoId, Produto model);

         Task<bool> DeletarProduto(int produtoId);
        //Produto
        //Ler um Produto por id mostrar todos os dados
         Task<Produto> BuscarProdutoPorIdAsync(int Id);
         //Listar Produtos por Id ou Descricao ou Fornecedor ou Preço Minimo ou Preço Máximo
         IQueryable<Produto> BuscarProdutosPorFiltroAsync();
         
    }
}