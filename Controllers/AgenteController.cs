using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgenteController : ControllerBase
{
    private readonly ILogger<AgenteController> _logger;
    private readonly IAgente _agente;
    public AgenteController(ILogger<AgenteController> logger, IAgente agente)
    {
        _logger = logger;
        _agente = agente;
    }

    [HttpPost("CriarAgente")]
    public async Task<DTO_Resposta> CriarAgente(DTO_Agente agente)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        Random random = new Random();
        int valeu = random.Next(1, 100);
        resposta = await _agente.CadastrarAgente(agente);
        return resposta;
    }

    [HttpPost("LogarAgente")]
    public DTO_Resposta LogarAgente(DTO_Login login)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _agente.LogarAgente(login);
        return resposta;
    }

    [HttpDelete("RemoverAgente")]
    public async Task<DTO_Resposta> RemoverAgenter(int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _agente.RemoverAgente(id);
        return resposta;
    }



}
