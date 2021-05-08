using System.Threading.Tasks;
using SupZezinho.Domain.models;

namespace SupZezinho.Repository
{
    public interface IFornecedoresRepositry
    {
         //Fornecedores 
         //Ler um fornecedor todos os dados + todos os produtos
          Task<Fornecedor> BuscarFornecedorPorIdAsync(int Id);
         //Listar Fornecedores com Nome e Id de cada
          Task<Fornecedor[]> BuscarFornecedoresAsync();
    }
}