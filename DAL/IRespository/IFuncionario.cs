using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IFuncionario
{
    Task<DTO_Resposta> CadastrarFuncionario();
}