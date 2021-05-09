using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupZezinho.Domain.models;

namespace SupZezinho.Repository
{
    public class FornecedoresRrepository : IFornecedoresRepositry
    {
        private readonly SupZezinhoContext _context;
        public FornecedoresRrepository(SupZezinhoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Fornecedor> BuscarFornecedorPorIdAsync(int Id)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores.Include(p => p.ProdutoFornecedor
                                      .Where(p => p.FornecedorId == Id));
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Fornecedor[]> BuscarFornecedoresAsync()
        {
            IQueryable<Fornecedor> query = _context.Fornecedores.OrderBy(f => f.Id)
                                            .Include(f => f.ProdutoFornecedor)
                                            .ThenInclude(p => p.Produto);
            return await query.ToArrayAsync();
        }
    }
}