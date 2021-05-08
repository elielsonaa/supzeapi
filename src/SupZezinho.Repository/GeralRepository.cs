using System.Threading.Tasks;

namespace SupZezinho.Repository
{
    public class GeralRepository :IGeralRepository
    {
        private readonly SupZezinhoContext _context;
        public GeralRepository(SupZezinhoContext context)
        {
            _context = context;
        }
         public void Adicionar<T>(T entidade) where T : class
        {
            _context.Add(entidade);
        }
        public void Atualizar<T>(T entidade) where T : class
        {
            _context.Update(entidade);
        }
        
        public void Deletar<T>(T entidade) where T : class
        {
            _context.Remove(entidade);
        }
        public void DeletarTudo<T>(T[] arrayEntidade) where T : class
        {
            _context.RemoveRange(arrayEntidade);
        }

        public async Task<bool> SalvaAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; //Consulta alterações
        }
    }
}