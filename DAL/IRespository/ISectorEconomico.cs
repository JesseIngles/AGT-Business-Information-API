using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface ISectorEconomico
{
        Task<DTO_Resposta> CadastrarSectorEconomico(DTO_SectorEconomico SectorEconomico);
        DTO_Resposta LogarSectorEconomico(DTO_Login login);
        Task<DTO_Resposta> AtualizarSectorEconomico(DTO_SectorEconomico SectorEconomico, int id);
}
