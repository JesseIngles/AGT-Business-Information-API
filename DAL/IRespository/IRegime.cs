using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IRegime
{
    Task<DTO_Resposta> CadastrarRegime();
}