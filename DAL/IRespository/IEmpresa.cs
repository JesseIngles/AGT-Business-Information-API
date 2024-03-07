using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IEmpresa
{
    Task<DTO_Resposta> CadastrarEmpresa(DTO_Empresa empresa);
    Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id);
}