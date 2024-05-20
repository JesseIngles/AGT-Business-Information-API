using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CRegime : IRegime
    {
        private readonly MyDbContext _db;
        public CRegime(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> AtualizarRegime(DTO_Regime regime, int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var regimeExistente = _db.TbRegime.First(r => r.Id == id);
                if (regimeExistente == null)
                {
                    resposta.mensagem = "Não existe";
                    return resposta;
                }
                regimeExistente.Nome = regime.Nome;
                await _db.SaveChangesAsync();
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> CadastrarRegime(DTO_Regime regime)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                if (regime == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                var NovoRegime = new Regime
                {
                    Nome = regime.Nome
                };
                await _db.TbRegime.AddAsync(NovoRegime);
                _db.SaveChanges();
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> RemoverRegime(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var regimeExistente = _db.TbRegime.First(r => r.Id == id);
                if (regimeExistente == null)
                {
                    resposta.mensagem = "Não existe";
                    return resposta;
                }
                _db.TbRegime.Remove(regimeExistente);
                await _db.SaveChangesAsync();
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public DTO_Resposta TodosRegimes()
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                resposta.resposta = _db.TbRegime.ToList();
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






















