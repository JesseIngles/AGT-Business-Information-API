using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TipoEmpresaController : ControllerBase
{
    private readonly ILogger<TipoEmpresaIdController> _logger;
    private readonly ITipoEmpresa _TipoEmpresa;
    public TipoEmpresaController(ILogger<TipoEmpresaController> logger, ITipoEmpresa TipoEmpresa)
    {
        _logger = logger;
        _TipoEmpresa = tipoEmpresa;
    }

    [HttpPost(Name = "TipoEmpresa")]
    public async Task<DTO_Resposta> CriarTipoEmpresa(DTO_TipoEmpresa tipoEmpresa)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _tipoEmpresa.CadastrarTipoEmpresa(tipoEmpresa);
        return resposta;
    } 
                                                                                                                              
    }