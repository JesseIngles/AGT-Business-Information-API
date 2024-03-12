using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;

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

        public Task<DTO_Resposta> CadastrarFuncionario(DTO_Funcionario funcionario)
        {
            throw new NotImplementedException();
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