using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CTipoEmpresa : ITipoEmpresa
    {
        private readonly MyDbContext _db;
        public CTipoEmpresa(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> CadastrarTipoEmpresa(DTO_TipoEmpresa tipoempresa)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var NovoTipoEmpresa = new TipoEmpresa
                {
                    Nome = tipoempresa.Nome
                };
                if(NovoTipoEmpresa== null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                _db.TbTipoEmpresa.Add(NovoTipoEmpresa);
                await _db.SaveChangesAsync();

                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> RemoverTipoEmpresa(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var TipoEmpresaExistente = _db.TbTipoEmpresa.FirstOrDefault(t => t.Id == id);
                if(TipoEmpresaExistente== null)
                {
                    resposta.mensagem = "Não existe";
                    return resposta;
                }
                _db.TbTipoEmpresa.Remove(TipoEmpresaExistente);
                await _db.SaveChangesAsync();
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }
    }
}
       
                
      


                
                
           
         
    

                     
                         
                   
                                                                           
  


            
                      
