using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class EmpresaController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;
    private readonly IEmpresa _empresa;
    public EmpresaController(ILogger<EmpresaController> logger, IEmpresa empresa)
    {
        _logger = logger;
        _empresa = empresa;
    }

    [HttpPost(Name = "CriarEmpresa")]
    public DTO_Resposta CriarEmpresa(Empresa empresa)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _empresa.CadastrarEmpresa(empresa).Result;
        return resposta;
    }

}
