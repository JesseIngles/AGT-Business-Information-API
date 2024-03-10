using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IEmpresa
{
    Task<DTO_Resposta> CadastrarEmpresa(DTO_Empresa empresa);
    Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id);
<<<<<<< HEAD
    Task <DTO_Resposta> PesquisarEmpresa(string consulta);
    

=======
    DTO_Resposta PesquisarEmpresa(string consulta);
    Task<DTO_Resposta> VerEmpresaId(int id);
>>>>>>> 7e557ab7321498070d65e1dcb591417ba3872f83
}