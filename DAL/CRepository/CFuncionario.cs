using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CFuncionario : IFuncionario
    {
        private readonly MyDbContext _db;
        public CFuncionario(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> CadastrarFuncionario(DTO_Funcionario funcionario)
        {  
           
               DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
           throw new NotImplementedException();
        }

        public Task<DTO_Resposta> PesquisarFuncionario(string consulta)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var FuncionarioExistentes = _db.TbFuncionario.ToList();
                resposta.resposta = FuncionarioExistentes.Select(e => new { Funcionario = e, Pontuacao = Fuzz.PartialRatio( e.PrimeiroNome, e.UltimoNome) }); 
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
          

            