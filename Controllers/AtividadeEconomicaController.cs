using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

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

    [HttpPost("CriarAtividadeEconomica")]
    public async Task<DTO_Resposta> AdicionarAtividadeEconomica(DTO_AtividadeEconomica atividadeEconomica)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _atividadeeconomica.CadastrarAtividadeEconomica(atividadeEconomica);
        return resposta;
    }
}