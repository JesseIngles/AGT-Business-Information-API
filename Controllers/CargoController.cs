using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class CargoController : ControllerBase
{
    private readonly ILogger<CargoController> _logger;
    private readonly ICargo _cargo;
    public CargoController(ILogger<CargoController> logger, ICargo cargo)
    {
        _logger = logger;
        _cargo = cargo;
    }

    [HttpPost(Name = "CriarCargo")]
    public async Task<DTO_Resposta> CriarRegime(DTO_Cargo cargo)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _cargo.CadastrarRegistro(cargo);
        return resposta;
    }                                                                                                                           
    }