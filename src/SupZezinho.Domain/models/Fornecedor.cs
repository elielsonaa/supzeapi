using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SupZezinho.Domain.models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O nome do fornecedor deve ter entre 10 e 50 caracteres.")]
        public string Nome { get; set; }
        //public Produto Produtos {get; set;}
        public IEnumerable<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    }
}