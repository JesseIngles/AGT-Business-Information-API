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
            throw new NotImplementedException();
        }

        public Task<DTO_Resposta> AtualizarFuncionario(DTO_Funcionario funcionario, int id)
        {
            throw new NotImplementedException();
        }

        public DTO_Resposta CadastrarFuncionario(DTO_Funcionario funcionario)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var Novofuncionario = new Funcionario
                {
                    PrimeiroNome = funcionario.PrimeiroNome,
                    UltimoNome = funcionario.UltimoNome,
                    Nif = funcionario.Nif,
                    CV = funcionario.CV,
                    Foto = funcionario.Foto
                };
                if(Novofuncionario==null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                _db.TbFuncionario.Add(Novofuncionario);
                _db.SaveChanges();
                if(funcionario.Emails != null)
                {
                    foreach(var item in funcionario.Emails)
                    {
                        var NovoEmail = new FuncionarioEmail
                        {
                            Email = item,
                            FuncionarioId = _db.TbFuncionario.First(x => x.Nif == funcionario.Nif).Id
                        };
                        _db.TbFuncionarioEmail.Add(NovoEmail);
                        _db.SaveChanges();
                    }
                }
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public DTO_Resposta PesquisarFuncionario(string consulta)
        {
            throw new NotImplementedException();
        }

        public DTO_Resposta RemoverFuncionario(int id)
        {
            throw new NotImplementedException();
        }
    }
}


