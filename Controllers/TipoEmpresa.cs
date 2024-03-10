using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TipoEmpresaController : ControllerBase
{
    private readonly ILogger<TipoEmpresaController> _logger;
    private readonly ITipoEmpresa _tipoEmpresa;
    public TipoEmpresaController(ILogger<TipoEmpresaController> logger, ITipoEmpresa tipoEmpresa)
    {
        _logger = logger;
        _tipoEmpresa = tipoEmpresa;
    }

    [HttpPost("TipoEmpresa")]
    public async Task<DTO_Resposta> CriarTipoEmpresa(DTO_TipoEmpresa tipoEmpresa)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _tipoEmpresa.CadastrarTipoEmpresa(tipoEmpresa);
        return resposta;
    }

    [HttpDelete("RemoverTipoEmpresa")]
    public async Task<DTO_Resposta> RemoverTipoEmpresa(int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _tipoEmpresa.RemoverTipoEmpresa(id);
        return resposta;
    }

}