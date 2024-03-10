using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface ITipoEmpresa
{
    Task<DTO_Resposta> CadastrarTipoEmpresa(DTO_TipoEmpresa tipoempresa);
    Task<DTO_Resposta> RemoverTipoEmpresa(int id);
    
}
