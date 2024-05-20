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
public class RegimeController : ControllerBase
{
    private readonly ILogger<RegimeController> _logger;
    private readonly IRegime _regime;
    public RegimeController(ILogger<RegimeController> logger, IRegime regime)
    {
        _logger = logger;
        _regime = regime;
    }
    //[Authorize("SerAgente")]
    [HttpPost("CriarRegime")]
    public async Task<DTO_Resposta> CriarRegime(DTO_Regime regime)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _regime.CadastrarRegime(regime);
        return resposta;
    }
    //[Authorize("SerAgente")]
    [HttpDelete("ApagarRegime")]
    public async Task<DTO_Resposta> ApagarRegime(int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _regime.RemoverRegime(id);
        return resposta;
    }
    //[Authorize("SerAgente")]
    [HttpPut("AtualizarRegime")]
    public async Task<DTO_Resposta> AtualizarRegime(DTO_Regime regime, int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _regime.AtualizarRegime(regime, id);
        return resposta;
    }
    [AllowAnonymous]
    [HttpGet("ListarRegimes")]
    public DTO_Resposta ListarRegimes()
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _regime.TodosRegimes();
        return resposta;
    }
}