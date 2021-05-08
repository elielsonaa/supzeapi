using System;
using Microsoft.EntityFrameworkCore;
using SupZezinho.Domain.models;

namespace SupZezinho.Repository
{
    public class SupZezinhoContext: DbContext 
    {
        public SupZezinhoContext(DbContextOptions<SupZezinhoContext> options): base(options){}

        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<ProdutoFornecedor> ProdutosFornecedores {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoFornecedor>()
                        .HasKey(pf => new {pf.ProdutoId, pf.FornecedorId});
        }
    }
}
