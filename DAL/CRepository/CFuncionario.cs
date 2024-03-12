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

        public DTO_Resposta AssociarFuncionarioEmpresa(int funcionarioid, int empresaid, int cargoid)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var Associacao = new EmpresaFuncionario
                {
                    FuncionarioId = funcionarioid,
                    EmpresaId = empresaid,
                    CargoId = cargoid
                };
                if (Associacao != null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                _db.TbEmpresaFuncionario.Add(Associacao);
                _db.SaveChanges();
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> AtualizarFuncionario(DTO_Funcionario funcionario, int id)
        {
                DTO_Resposta resposta = new DTO_Resposta();
            try 
            {
                var FuncionarioExistentes = _db.TbFuncionario.First(f => f.Id == id);
                if (FuncionarioExistentes != null)
                {
                    FuncionaioExistentes.Nif = funcionario.Nif;
                    FuncionarioExistentes.PrimeiroNome = funcionario.PrimeiroNome;
                    await _db.SaveChangesAsync();
                    resposta.mensagem = "Sucesso";
                    return resposta; 
                }
                  resposta.mensagem = "Dados invalidos";
            }

                  catch(System.Exception ex)
                  { 
                       resposta.mensagem = ex.ToString();
                  }
                  return resposta;
           }
         
        }

        public async Task<DTO_Resposta> CadastrarFuncionario(DTO_Funcionario funcionario)
        {

            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var NovoFuncionario = new Funcionario
                {
                    PrimeiroNome = funcionario.PrimeiroNome,
                    UltimoNome = funcionario.UltimoNome,
                    CV = funcionario.CV,
                    Nif = funcionario.Nif,
                    Foto = funcionario.Foto
                };
                if (NovoFuncionario == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                _db.TbFuncionario.Add(NovoFuncionario);
                await _db.SaveChangesAsync();
                if (funcionario.Emails != null)
                {
                    foreach (var item in funcionario.Emails)
                    {
                        var novoEmail = new FuncionarioEmail
                        {
                            Email = item,
                            FuncionarioId = _db.TbFuncionario.First(e => e.Nif == NovoFuncionario.Nif).Id
                        };
                        await _db.TbFuncionarioEmail.AddAsync(novoEmail);
                        _db.SaveChanges();
                    }
                }
                if (funcionario.Telefones != null)
                {
                    foreach (var item in funcionario.Telefones)
                    {
                        var novoTelefone = new FuncionarioTelefone
                        {
                            Telefone = item,
                            FuncionarioId = _db.TbEmpresa.First(e => e.Nif == NovoFuncionario.Nif).Id
                        };
                        await _db.TbFuncionarioTelefone.AddAsync(novoTelefone);
                        _db.SaveChanges();
                    }
                }
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public DTO_Resposta PesquisarFuncionario(string consulta)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var FuncionarioExistentes = _db.TbFuncionario.ToList();
                resposta.resposta = FuncionarioExistentes.Select(e => new { Funcionario = e, Pontuacao = Fuzz.PartialRatio(consulta, e.UltimoNome) });
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }
    }



