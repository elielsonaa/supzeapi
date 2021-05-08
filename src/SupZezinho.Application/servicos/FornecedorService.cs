using System;
using System.Linq;
using System.Threading.Tasks;
using SupZezinho.Application.contratos;
using SupZezinho.Domain.models;
using SupZezinho.Repository;

namespace SupZezinho.Application
{
    public class FornecedorService : IFornecedorServices
    {
        private readonly IGeralRepository _geralrepository;
        private readonly IFornecedoresRepositry _fornecedoreRepository;
        public FornecedorService(IGeralRepository geralrepository, IFornecedoresRepositry fornecedoreRepository)
        {
            _fornecedoreRepository = fornecedoreRepository;
            _geralrepository = geralrepository;

        }
        public async Task<Fornecedor> AdicionarFornecedor(Fornecedor model)
        {
            try
            {
               _geralrepository.Adicionar<Fornecedor>(model);
                if (!await _geralrepository.SalvaAlteracoesAsync())
                    return null;
                else
                    return await _fornecedoreRepository.BuscarFornecedorPorIdAsync(model.Id);
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public async Task<Fornecedor> AtualizarFornecedor(int fornecedorId, Fornecedor model)
        {
            try
            {
              var fornecedor = await _fornecedoreRepository.BuscarFornecedorPorIdAsync(fornecedorId);
              if(fornecedor == null) return null;
              model.Id = fornecedor.Id;
              _geralrepository.Atualizar(model);
              if (!await _geralrepository.SalvaAlteracoesAsync())
                    return null;
                else
                    return await _fornecedoreRepository.BuscarFornecedorPorIdAsync(model.Id);
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeletarFornecedor(int fornecedorId)
        {
            try
            {
              var fornecedor = await _fornecedoreRepository.BuscarFornecedorPorIdAsync(fornecedorId);
              if(fornecedor == null) throw new Exception("Fornecedor não encontrado!");
              if(fornecedor.ProdutoFornecedor.Count() > 0) throw new Exception("Existem produtos amarrados a esse fornecedor. O mesmo não pode ser deletado!");
              else
              _geralrepository.Deletar<Fornecedor>(fornecedor);
              return await _geralrepository.SalvaAlteracoesAsync();
          
            }
            catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public async Task<Fornecedor> BuscarFornecedorPorIdAsync(int Id)
        {
            try 
            {
                var fornecedor = await _fornecedoreRepository.BuscarFornecedorPorIdAsync(Id);
                if(fornecedor == null) throw new Exception("Fornecedor não encontrado!");
                return fornecedor;
            }
             catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public async Task<Fornecedor[]> BuscarFornecedoresAsync()
        {
            try 
            {
                var fornecedores = await _fornecedoreRepository.BuscarFornecedoresAsync();
                if(fornecedores == null) throw new Exception("Nenum fornecedor encontrado!");
                return fornecedores;
            }
             catch(Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }
    }
}