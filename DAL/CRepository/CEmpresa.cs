using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CEmpresa : IEmpresa
    {
        private readonly MyDbContext _db;
        public CEmpresa(MyDbContext context)
        {
            _db = context;
        }
        public async Task<DTO_Resposta> CadastrarEmpresa(DTO_Empresa empresa)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var empresaExistente = new Empresa
                {
                    Firma = empresa.Firma,
                    Nif = empresa.Nif,
                    DataFundacao = empresa.DataFundacao,
                    Logotipo = ConverterImagemService.ConverterParaBase64(empresa.Logotipo),
                    Ativo = empresa.Ativo,
                    SectorEconomicoId = empresa.SectorEconomicoId,
                    AtividadeEconomicaId = empresa.AtividadeEconomicaId,
                    TipoEmpresaId = empresa.TipoEmpresaId,
                    RegimeId = empresa.RegimeId,
                    EnderecoId = empresa.EnderecoId
                };
                if (empresaExistente == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                await _db.TbEmpresa.AddAsync(empresaExistente);
                _db.SaveChanges();
                if (empresa.Emails != null)
                {
                    foreach (var item in empresa.Emails)
                    {
                        var novoEmail = new EmpresaEmail
                        {
                            Email = item,
                            EmpresaId = _db.TbEmpresa.Find(empresaExistente).Id
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
    public AtualixarEmpresa()
    {
    Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id)
    {
         DTO_Actualizar = new DTO_Atualizar();
         try 
         {
             TbEmpresa empresa = _db.TbEmpresa.FirstOrDeafult(c => c.Id == id);
         }
         
                if (empresa != null)
                {
                    id = empresa.id,
                    nome = empresa.nome,
                    RegimeId = empresa.RegimeId,
                    EnderecoId = empresa.EnderecoId
                     
                     _db.SaveChanges();
                     resposta.mensagem = "Dados atualizados com sucesso";
                    return resposta;

                };
                  else
                {
                    resposta.resposta = "Empresa não encontrada";
                    resposta.mensagem = "Não foi possível encontrar a empresa para edição";
                }
            }
            catch (Exception ex)
            {
                resposta.resposta = ex.Message;
                resposta.mensagem = "Não foi possível concluir a operação com sucesso";
            }
                        return resposta;
    }
    }
    public DTO_Resposta PesquisarEmpresa(string consulta)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        var EmpresasExistentes = _db.TbEmpresa.ToList();
        var resultados = EmpresasExistentes.Select(e => new { empresa = e, Pontuacao = Fuzz.PartialRatio(consulta, e.Nome) });
        resposta.resposta = resultados;
        return resposta;
    }