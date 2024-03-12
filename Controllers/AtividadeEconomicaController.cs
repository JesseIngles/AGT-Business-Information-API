using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[EnableCors("BackOfficeAgentes")]
[ApiController]
[Route("[controller]/v1/")]
public class AtividadeEconomicaController : ControllerBase
{
    private readonly ILogger<AtividadeEconomicaController> _logger;
    private readonly IAtividadeEconomica _atividadeeconomica;
    public AtividadeEconomicaController(ILogger<AtividadeEconomicaController> logger, IAtividadeEconomica AtividadeEconomica)
    {
        _logger = logger;
        _atividadeeconomica = AtividadeEconomica;
    }
    [Authorize("SerAgente")]
    [HttpPost("CriarAtividadeEconomica")]
    public async Task<DTO_Resposta> AdicionarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _atividadeeconomica.CadastrarAtividadeEconomica(atividadeEconomica);
        return resposta;
    }
    [Authorize("SerAgente")]
    [HttpPut("AtualizarAtividadeEconomica")]
    public async Task<DTO_Resposta> AtualizarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica, int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _atividadeeconomica.AtualizarAtividadeEconomica(atividadeEconomica, id);
        return resposta;
    }
    [AllowAnonymous]
    [HttpGet("VisualizarAtividadesEconomicas")]
    public async Task<DTO_Resposta> TodasAtividadesEconomicas()
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _atividadeeconomica.TodasAtividadesEconomicas();
        return resposta;
    }
}