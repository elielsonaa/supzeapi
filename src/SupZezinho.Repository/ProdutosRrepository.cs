using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.EntityFrameworkCore;
using SupZezinho.Domain.models;

namespace SupZezinho.Repository
{
    public class ProdutosRrepository : IProdutosRepositry
    {
        
        private readonly SupZezinhoContext _context;
        public ProdutosRrepository(SupZezinhoContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Produto> BuscarProdutoPorIdAsync(int Id)
        {
            IQueryable<Produto> query = _context.Produtos.Include(f => f.ProdutoFornecedor);
             query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);
             return await query.FirstOrDefaultAsync();
        }
        public  IQueryable<Produto> BuscarProdutosPorFiltroAsync()
        {      
            IQueryable<Produto> query = _context.Produtos.AsQueryable();       
            return query;     
        }
    }
}