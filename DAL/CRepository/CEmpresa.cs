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


       public DTO_Resposta AtualizarEmpresa(DTO_Empresa empresa, int id,MyDbContext _db)
         {
               DTO_Resposta  resposta  = new DTO_Resposta();
         try 
         {
              var tbempresaexistente = _db.TbEmpresa.FirstOrDefault(c => c.Id == id);
             
                if (tbempresaexistente != null)
                {
                    
                    Emails = empresa.Emails;

                     _db.SaveChanges();
                     resposta.mensagem = "Dados atualizados com sucesso";
                    return resposta;

                }
                  else
                {
                    resposta.resposta = "modelo não encontrada";
                    resposta.mensagem = "Não foi possível encontrar a modelo para edição";

    }

        public async Task<DTO_Resposta> VerEmpresa(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                resposta.resposta = await _db.TbEmpresa.FirstAsync(empresa => empresa.Id == id);
                if(resposta.resposta!=null)
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

        public async Task<DTO_Resposta> RemoveEmpresa(int id)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var empresaExistente = _db.TbEmpresa.First(empresa => empresa.Id == id);
                if(empresaExistente != null)
                {
                    var emails = _db.TbEmailEmpresa.Where( e => e.EmpresaId == empresaExistente.Id);
                    foreach(var email in emails)
                    {
                        _db.TbEmailEmpresa.Remove(email);
                        await _db.SaveChangesAsync();
                    }
                    var telefones = _db.TbTelefoneEmpresa.Where( e => e.EmpresaId == empresaExistente.Id);
                    foreach(var telefone in telefones)
                    {
                        _db.TbTelefoneEmpresa.Remove(telefone);
                        await _db.SaveChangesAsync();
                    }
                    _db.TbEmpresa.Remove(empresaExistente);
                    await _db.SaveChangesAsync();
                    resposta.mensagem = "Sucesso";
                }
                resposta.mensagem = "Não existe";
            }  
            catch (Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
 
                        return resposta;
    }
                     
    
        public  DTO_Resposta PesquisarEmpresa(string consulta)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        var EmpresasExistentes = _db.TbEmpresa.ToList();
        var resultados = EmpresasExistentes.Select(e => new { empresa = e, Pontuacao = Fuzz.PartialRatio(consulta, e.Nome) });
        resposta.resposta = resultados;
        return resposta;

    }


          }
          
} 
}
}