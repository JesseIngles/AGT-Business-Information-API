using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.CRepository
{
    public class CAtividadeEconomica : IAtividadeEconomica
    {
        private readonly MyDbContext _db;
        public CAtividadeEconomica(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> AtualizarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica, int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var AtividadeEconomicaExistente = _db.TbActividadeEconomica.First(a => a.Id == id);
                if (AtividadeEconomicaExistente == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                AtividadeEconomicaExistente.Nome = atividadeEconomica.Nome;
                await _db.SaveChangesAsync();
                resposta.mensagem = "Atualizado com sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> CadastrarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var NovaAtividadeEconomica = new ActividadeEconomica
                {
                    Nome = atividadeEconomica.Nome
                };
                if (NovaAtividadeEconomica == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                _db.TbActividadeEconomica.Add(NovaAtividadeEconomica);
                await _db.SaveChangesAsync();
                resposta.mensagem = "Criado com sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> TodasAtividadesEconomicas()
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                resposta.resposta = await _db.TbActividadeEconomica.ToListAsync();
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