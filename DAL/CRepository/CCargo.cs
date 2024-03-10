using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CCargo : ICargo
    {
        private readonly MyDbContext _db;
        public CCargo(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> AtualizarCargo(DTO_Cargo cargo, int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var CargoExistente = _db.TbCargo.First(a => a.Id == id);
                if (CargoExistente != null)
                {
                    CargoExistente.Nome = cargo.Nome;
                    await _db.SaveChangesAsync();
                    resposta.mensagem = "Sucesso";
                    return resposta;
                }
                resposta.mensagem = "Não existe";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> CadastrarCargo(DTO_Cargo )
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var NovoCargo = new cargo
                {
                    Nome = cargo.Nome,
                };
                if (NovoCargo == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
            
                
        
        }

    
                
            
        }

    }

}

