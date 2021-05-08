using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SupZezinho.Domain.models
{
    public class Produto
    {
        public int Id { get; set; }
                
        [StringLength(300, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 300 caracteres.")]
        public string Descricao { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0,c}")]  
        public decimal Preco { get; set; }

         [Range(1, 99999, ErrorMessage="O estoque não pode ser menor que 0")]         
         public int Estoque { get; set; }
         public int FornecedorId { get; set; }
         //public Fornecedor Fornecedor { get; set; }
         public IEnumerable<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    }
}