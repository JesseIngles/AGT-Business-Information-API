using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.IRepository;

public interface IAgente
{
        Task<DTO_Resposta> CadastrarAgente(DTO_Agente agente);
        DTO_Resposta LogarAgente(DTO_Login login);
        Task<DTO_Resposta> AtualizarAgente(DTO_Agente agente, int id);
}
