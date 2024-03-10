using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IFuncionario
{
    Task<DTO_Resposta> AtualizarFuncionario(DTO_Funcionario funcionario, int id);
    Task<DTO_Resposta> CadastrarFuncionario(DTO_Funcionario funcionario);
    Task<DTO_Resposta> PesquisarFuncionario(string consulta);
}