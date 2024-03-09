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
        public async Task<DTO_Resposta> CadastrarAgente(DTO_Agente agente)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var agenteExistente = new Empresa
                {
                    Id = Agente.Id
                    Nif = Agente.Nif,
                    Nome = Agente.Nome,
                    Ativo = Agente.Ativo,
                    Senha= Agente.Senha,
                    isAdmin = Agente.isAdmin,
                     
                    
                };
                if (AgenteExistente == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                await _db.TbAgente.AddAsync(AgenteExistente);
                _db.SaveChanges();
                if (agente.Emails != null)
                {
                    foreach (var item in agente.Emails)
                    {
                        var novoEmail = new EmpresaEmail
                        {
                            Email = item,
                            EmpresaId = _db.TbAgente.Find(agenteExistente).Id
                        };
                        await _db.TbEmailEmpresa.AddAsync(novoEmail);
                        _db.SaveChanges();
                    }
                }
                if (empresa.Telefones != null)
                {
                    foreach (var item in empresa.Telefones)
                    {
                        var novoTelefone = new EmpresaTelefone
                        {
                            Telefone = item,
                            EmpresaId = _db.TbEmpresa.Find(empresaExistente).Id
                        };
                        await _db.TbTelefoneEmpresa.AddAsync(novoTelefone);
                        _db.SaveChanges();
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

        

          }
          
        }
            