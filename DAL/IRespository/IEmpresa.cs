using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IEmpresa
{
    Task<DTO_Resposta> CadastrarEmpresa(DTO_Empresa empresa);
    Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id);
    DTO_Resposta PesquisarEmpresa(string consulta);
    Task<DTO_Resposta> VerEmpresaId(int id);
}