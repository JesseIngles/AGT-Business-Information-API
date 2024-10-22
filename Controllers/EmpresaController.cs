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
public class EmpresaController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;
    private readonly IEmpresa _empresa;
    public EmpresaController(ILogger<EmpresaController> logger, IEmpresa empresa)
    {
        _logger = logger;
        _empresa = empresa;
    }
    //[Authorize("SerAgente")]
    [HttpPost("CriarEmpresa")]
    public async Task<DTO_Resposta> CriarEmpresa(DTO_Empresa empresa)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _empresa.CadastrarEmpresa(empresa);
        return resposta;
    }
    //[Authorize("SerAgente")]
    [HttpPut("AtualizarEmpresa")]
    public async Task<DTO_Resposta> AtualizarEmpresa(DTO_Empresa empresa, int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _empresa.AtualizarEmpresa(empresa, id);
        return resposta;
    }
    [AllowAnonymous]
    [HttpGet("PesquisarEmpresa")]
    public DTO_Resposta PesquisarEmpresa(string consulta)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _empresa.PesquisarEmpresa(consulta);
        return resposta;
    }

    //[Authorize("SerAgente")]
    [HttpDelete("RemoverEmpresa")]
    public async Task<DTO_Resposta> RemoverEmpresa(int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _empresa.RemoverEmpresa(id);
        return resposta;
    }

    [AllowAnonymous]
    [HttpGet("EmpresaFuncionarios")]
    public DTO_Resposta EmpresaFuncionario(int empresaId)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _empresa.EmpresaFuncionarios(empresaId);
        return resposta;
    }
}
