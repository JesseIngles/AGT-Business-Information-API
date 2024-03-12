using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.DAL.CRepository
{
    public class CEmpresa : IEmpresa
    {
        private readonly MyDbContext _db;
        public CEmpresa(MyDbContext context)
        {
            _db = context;
        }
        //Atualiza o registro do id especificado com a informações passadas no objecto empresa
        public async Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var tbempresaexistente = _db.TbEmpresa.FirstOrDefault(c => c.Id == id);

                if (tbempresaexistente != null)
                {
                    tbempresaexistente.Firma = empresa.Firma;
                    tbempresaexistente.Nif = empresa.Nif;
                    tbempresaexistente.DataFundacao = empresa.DataFundacao;
                    tbempresaexistente.Logotipo = ConverterImagemService.ConverterParaBase64(empresa.Logotipo);
                    await _db.SaveChangesAsync();

                    resposta.mensagem = "Dados atualizados com sucesso";
                    return resposta;
                }
                resposta.mensagem = "Dados inválidos";
            }
            catch (Exception ex)
            {
                resposta.resposta = ex.Message;
                resposta.mensagem = "Não foi possível concluir a operação com sucesso";
            }
            return resposta;
        }
        //Cadastra uma empresa com base nas informações provinientes do DTO_Empresa
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
                            EmpresaId = _db.TbEmpresa.First(e => e.Nif == empresaExistente.Nif).Id
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
                            EmpresaId = _db.TbEmpresa.First(e => e.Nif == empresaExistente.Nif).Id
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

        //Pesquisa um empresa usando um algoritmo de pesquisa, denominado Fuzz Sharp
        public DTO_Resposta PesquisarEmpresa(string consulta)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var EmpresasExistentes = _db.TbEmpresa.ToList();
                var Empresas = EmpresasExistentes.Select(e => new
                {
                    empresa = e,
                    Pontuacao = Fuzz.PartialRatio(consulta.ToLower(), e.Firma.ToLower())
                                            + Fuzz.PartialRatio(consulta.ToLower(), e.Nif.ToLower())
                });
                //resposta.resposta = Empresas.Where(x => x.Pontuacao >= 60);
                resposta.resposta = from e in Empresas 
                                    where e.Pontuacao >= 60
                                    select new 
                                    {
                                        Nome = e.empresa.Firma,
                                        Nif = e.empresa.Nif
                                    };
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }
        public async Task<DTO_Resposta> VerEmpresa(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                resposta.resposta = await _db.TbEmpresa.FirstAsync(empresa => empresa.Id == id);
                if (resposta.resposta != null)
                {
                    resposta.mensagem = "Sucesso";
                }
                resposta.resposta = null;
                resposta.resposta = "Não existe";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public async Task<DTO_Resposta> RemoverEmpresa(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var empresaExistente = _db.TbEmpresa.First(empresa => empresa.Id == id);
                if (empresaExistente != null)
                {
                    var emails = _db.TbEmailEmpresa.Where(e => e.EmpresaId == empresaExistente.Id);
                    foreach (var email in emails)
                    {
                        _db.TbEmailEmpresa.Remove(email);
                    }
                    await _db.SaveChangesAsync();
                    var telefones = await _db.TbTelefoneEmpresa.Where(e => e.EmpresaId == empresaExistente.Id).ToListAsync();
                    foreach (var telefone in telefones)
                    {
                        _db.TbTelefoneEmpresa.Remove(telefone);
                    }
                    _db.SaveChanges();
                    _db.TbEmpresa.Remove(empresaExistente);
                    await _db.SaveChangesAsync();
                    resposta.mensagem = "Sucesso";
                    return resposta;
                }
                resposta.mensagem = "Não existe";
            }
            catch (Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public DTO_Resposta EmpresaFuncionarios(int empresaId)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var empresafuncionarios = from b in _db.TbEmpresaFuncionario
                                          where b.EmpresaId == empresaId
                                          select new
                                          {
                                              Cargo = _db.TbCargo.First(c => c.Id == b.CargoId).Nome,
                                              Funcionario = _db.TbFuncionario.First(f => f.Id == b.FuncionarioId).PrimeiroNome
                                          };
                resposta.resposta = empresafuncionarios;
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