using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface ISectorEconomico
{
        Task<DTO_Resposta> CadastrarSectorEconomico(DTO_SectorEconomico sectorEconomico);
        Task<DTO_Resposta> AtualizarSectorEconomico(DTO_SectorEconomico sectorEconomico, int id);
}
