using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IAtividadeEconomica
{
    Task<DTO_Resposta> CadastrarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica);
    Task<DTO_Resposta> AtualizarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica, int id);
    Task<DTO_Resposta> TodasAtividadesEconomicas();
}