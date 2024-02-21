using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IEmpresa
{
    Task<DTO_Resposta> CadastrarEmpresa(Empresa empresa);
}