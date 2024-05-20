using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CEndereco : IEndereco
    {
        private readonly MyDbContext _db;
        public CEndereco(MyDbContext context)
        {
            _db = context;
        }

        public DTO_Resposta CadastrarEndereco(DTO_Endereco endereco)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                var NovoEndereco = new Endereco
                {
                    Pais = endereco.pais,
                    Provincia = endereco.provincia,
                    Municipio = endereco.municipio,
                    Bairro = endereco.bairro,
                    Rua = endereco.rua,
                    Ncasa = endereco.ncasa
                };
                if(NovoEndereco == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                _db.TbEndereco.Add(NovoEndereco);
                _db.SaveChanges();
                resposta.mensagem = "Sucesso";
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }

        public DTO_Resposta VisualizarEnderecos()
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                resposta.resposta = _db.TbEndereco.ToList();
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
