using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CSectorEconomico : ISectorEconomico
    {
        private readonly MyDbContext _db;
        public CSectorEconomico(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> AtualizarSectorEconomico(DTO_SectorEconomico sectorEconomico, int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var SectorEconomicoExistente = _db.TbSectorEconomico.First(a => a.Id == id);
                if (SectorEconomicoExistente != null)
                {
                    SectorEconomicoExistente.Nome = sectorEconomico.Nome;
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

        public async Task<DTO_Resposta> CadastrarSectorEconomico(DTO_SectorEconomico sectorEconomico)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                
                var NovoSectorEconomico = new SectorEconomico
                {
                    Nome = sectorEconomico.Nome         
                };
                if (NovoSectorEconomico == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }

                       
            }catch(Exception ex){

            }
            return resposta;
        }
       }
  }
       
                
      


                
                
           
         
    

                     
                         
                   
                                                                           
  


            
                      

                      
