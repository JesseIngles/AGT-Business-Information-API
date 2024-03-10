using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class AgenteController : ControllerBase
{
    private readonly ILogger<AgenteController> _logger;
    private readonly IAgente _agente;
    public AgenteController(ILogger<AgenteController> logger, IAgente agente)
    {
        _logger = logger;
        _agente = agente;
    }

    [HttpPost(Name = "CriarAgente")]
    public async Task<DTO_Resposta> CriarAgente(DTO_Agente agente)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _agente.CadastrarAgente(agente);
        return resposta;
    }

    [HttpPost(Name = "LogarAgente")]
    public DTO_Resposta LogarAgente(DTO_Login login)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _agente.LogarAgente(login);
        return resposta;
    }
    

    
}
