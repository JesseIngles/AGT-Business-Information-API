using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IRegime
{
    Task<DTO_Resposta> AtualizarRegime(DTO_Regime regime, int id);
    Task<DTO_Resposta> CadastrarRegime(DTO_Regime regime);
    Task<DTO_Resposta> RemoverRegime(int id);
}