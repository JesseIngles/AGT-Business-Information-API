using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IAgente
{
        Task<DTO_Resposta> CadastrarAgente(DTO_Agente agente);

}
