using System.Collections.Generic;

namespace SupZezinho.Domain.models
{
    public class ProdutoFornecedor
    {
      public int ProdutoId { get; set; }  
      public Produto  Produto { get; set; }
      public int FornecedorId { get; set; }
      public Fornecedor Fornecedor { get; set; }
    }
}