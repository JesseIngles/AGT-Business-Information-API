using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IFuncionario
{
    DTO_Resposta AssociarFuncionarioEmpresa(int funcionarioid, int empresaid, int cargoid);
    Task<DTO_Resposta> AtualizarFuncionario(DTO_Funcionario funcionario, int id);
    Task<DTO_Resposta> CadastrarFuncionario(DTO_Funcionario funcionario);
    DTO_Resposta PesquisarFuncionario(string consulta);
}