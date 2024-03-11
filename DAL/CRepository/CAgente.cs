using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CAgente : IAgente
    {
        private readonly MyDbContext _db;
        public CAgente(MyDbContext context)
        {
            _db = context;
        }

        public async Task<DTO_Resposta> AtualizarAgente(DTO_Agente agente, int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var AgenteExistente = _db.TbAgente.First(a => a.Id == id);
                if (AgenteExistente != null)
                {
                    AgenteExistente.Nif = agente.Nif;
                    AgenteExistente.Nome = agente.Nome;
                    AgenteExistente.Senha = agente.senha;
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

        public async Task<DTO_Resposta> CadastrarAgente(DTO_Agente agente)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var agentes = _db.TbAgente.ToList();
                var NovoAgente = new Agente
                {
                    Nome = agente.Nome,
                    Senha = agente.senha,
                    Nif = agente.Nif,
                    IsAdmin = (agentes.Count == 0) ? true : false
                };
                if (NovoAgente == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                await _db.TbAgente.AddAsync(NovoAgente);
                _db.SaveChanges();
                if (agente.Emails != null)
                {
                    foreach (var item in agente.Emails)
                    {
                        var novoEmail = new AgenteEmail
                        {
                            Email = item,
                            AgenteId = _db.TbAgente.First(r => r.Nif == NovoAgente.Nif).Id
                        };
                        _db.TbAgenteEmail.Add(novoEmail);
                        await _db.SaveChangesAsync();
                    }

                }
                if (agente.Telefones != null)
                {
                    foreach (var item in agente.Telefones)
                    {
                        var novoTelefone = new AgenteTelefone
                        {
                            Telefone = item,
                            AgenteId = _db.TbAgente.First(r => r.Nif == NovoAgente.Nif).Id
                        };
                        _db.TbAgenteTelefone.Add(novoTelefone);
                        await _db.SaveChangesAsync();
                    }
                }
                resposta.mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public DTO_Resposta LogarAgente(DTO_Login login)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var AgenteExistente = _db.TbAgente.First(a => a.Nif == login.Nif
                                                        && a.Senha == login.Senha);
                if (AgenteExistente != null)
                {
                    AgenteExistente.Ativo = true;
                    _db.SaveChanges();
                    resposta.resposta = JwtService.GerarTokenAgente();
                    resposta.mensagem = "Sucesso";
                    return resposta;
                }
                resposta.mensagem = "Nif ou senha inválidos";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> RemoverAgente(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var agenteExistente = _db.TbAgente.First(r => r.Id == id);
                if (agenteExistente == null)
                {
                    resposta.mensagem = "Não existe";
                    return resposta;
                }
                    var emails = _db.TbAgenteEmail.Where(e => e.AgenteId == agenteExistente.Id);
                    foreach (var email in emails)
                    {
                        _db.TbAgenteEmail.Remove(email);
                        await _db.SaveChangesAsync();
                    }
                    var telefones = _db.TbAgenteTelefone.Where(e => e.AgenteId == agenteExistente.Id);
                    foreach (var telefone in telefones)
                    {
                        _db.TbAgenteTelefone.Remove(telefone);
                        await _db.SaveChangesAsync();
                    }
                    _db.TbAgente.Remove(agenteExistente);
                    await _db.SaveChangesAsync();
                    resposta.mensagem = "Sucesso";
                _db.TbAgente.Remove(agenteExistente);
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
