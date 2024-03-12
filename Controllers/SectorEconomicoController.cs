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
public class SectorEconomicoController : ControllerBase
{
    private readonly ILogger<SectorEconomicoController> _logger;
    private readonly ISectorEconomico _sectorEconomico;
    public SectorEconomicoController(ILogger<SectorEconomicoController> logger, ISectorEconomico sectorEconomico)
    {
        _logger = logger;
        _sectorEconomico = sectorEconomico;
    }
    [Authorize("SerAgente")]
    [HttpPost("CriarSectorEconomico")]
    public async Task<DTO_Resposta> CriarSectorEconomico(DTO_SectorEconomico sectorEconomico)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _sectorEconomico.CadastrarSectorEconomico(sectorEconomico);
        return resposta;
    }
    [AllowAnonymous]
    [HttpGet("ListarSectoresEconomicos")]
    public async Task<DTO_Resposta> PegarSectoresEconomicos()
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _sectorEconomico.ListarSectoresEconomicos();
        return resposta;
    }


}
