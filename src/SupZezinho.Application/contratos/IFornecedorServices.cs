using System;
using System.Linq;
using System.Threading.Tasks;
using SupZezinho.Domain.models;

namespace SupZezinho.Application.contratos
{
    public interface IFornecedorServices
    {
         Task<Fornecedor> AdicionarFornecedor(Fornecedor model);
         Task<Fornecedor> AtualizarFornecedor(int fornecedorId, Fornecedor model);

         Task<bool> DeletarFornecedor(int fornecedorId);
        //Produto
        //Ler um Produto por id mostrar todos os dados
         Task<Fornecedor> BuscarFornecedorPorIdAsync(int Id);
         //Listar Produtos por Id ou Descricao ou Fornecedor ou Preço Minimo ou Preço Máximo
         Task<Fornecedor[]> BuscarFornecedoresAsync();
         
    }
}