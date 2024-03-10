using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class  SectorEconomicoController : ControllerBase
{
    private readonly ISectorEconomico<SectorEconomicoController> _logger;
    private readonly ISectorEconomico _agenSectorEconomico;
    public SectorEconomicoController(ILogger<SectorEconomicoController> logger, ISectorEconomico SectorEconomico)
    {
        _logger = logger;
        _SectorEconomico = SectorEconomico;
    }

    [HttpPost(Name = "CriarSectorEconomico")]

    public async Task<DTO_Resposta> CriarSectorEconomico (DTO_SectorEconomico sectorEconomico )

    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _SectorEconomico.CadastrarSectorEconomico(sectorEconomico);
        return resposta;
    }
    

    
}
