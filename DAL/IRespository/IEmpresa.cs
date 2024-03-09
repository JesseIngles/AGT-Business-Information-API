using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IEmpresa
{
    Task<DTO_Resposta> CadastrarEmpresa(DTO_Empresa empresa);
<<<<<<< HEAD
    //Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id);

    DTO_Resposta PesquisarEmpresa(string consulta);
=======
    Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id);
    Task <DTO_Resposta> PesquisarEmpresa(string consulta);
    
>>>>>>> Elly
}