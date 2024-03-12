using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[EnableCors("BackOfficeAgentes")]
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
    [AllowAnonymous]
    [HttpPost("CriarAgente")]
    public async Task<DTO_Resposta> CriarAgente(DTO_Agente agente)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _agente.CadastrarAgente(agente);
        return resposta;
    }
    [AllowAnonymous]
    [HttpPost("LogarAgente")]
    public DTO_Resposta LogarAgente(DTO_Login login)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _agente.LogarAgente(login);
        return resposta;
    }
    [Authorize("SerAgenteAdmin")]
    [HttpDelete("RemoverAgente")]
    public async Task<DTO_Resposta> RemoverAgenter(int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _agente.RemoverAgente(id);
        return resposta;
    }
    [Authorize("SerAgenteAdmin")]
    [HttpGet("ListarAgentes")]
    public DTO_Resposta VisualizarAgentes()
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta =  _agente.TodosAgentes();
        return resposta;
    }


}
