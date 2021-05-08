using System.Threading.Tasks;
using SupZezinho.Domain.models;

namespace SupZezinho.Repository
{
    public interface IGeralRepository
    {
        //Alterações Gegrais
         void Adicionar<T>(T entidade ) where T:class;
         void Atualizar<T>(T entidade ) where T:class;
         void Deletar<T>(T entidade ) where T:class;
         void DeletarTudo<T>(T[] entidade ) where T:class;
         
         Task<bool> SalvaAlteracoesAsync();
        
    }
}