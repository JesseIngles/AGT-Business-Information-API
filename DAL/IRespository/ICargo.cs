using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface ICargo
{
    Task<DTO_Resposta> CadastrarCargo();
    Task<DTO_Resposta> AtualizarCargo(DTO_Cargo cargo, int id);
}