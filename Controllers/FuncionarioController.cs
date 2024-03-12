using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CrudEmpresas.Controllers;

[EnableCors("BackOfficeAgentes")]
[ApiController]
[Route("[controller]/v1/")]
public class FuncionarioController : ControllerBase
{
    private readonly ILogger<FuncionarioController> _logger;
    private readonly IFuncionario _funcionario;
    public FuncionarioController(ILogger<FuncionarioController> logger, IFuncionario funcionario)
    {
        _logger = logger;
        _funcionario = funcionario;
    }
    [Authorize("RequiredClaims")]
    [HttpPost("AdicionarFuncionario")]
    public async Task<DTO_Resposta> CadastrarFuncionario(DTO_Funcionario funcionario)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _funcionario.CadastrarFuncionario(funcionario);
        return resposta;
    }

    [HttpPut("AtualizarFuncionario")]
    public async Task<DTO_Resposta> AtualizarFuncionario(DTO_Funcionario funcionario, int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _funcionario.AtualizarFuncionario(funcionario, id);
        return resposta;
    }
    [AllowAnonymous]
    [HttpGet("PesquisarFuncionario")]
    public DTO_Resposta PesquisarFuncionario(string consulta)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = _funcionario.PesquisarFuncionario(consulta);
        return resposta;
    }

}

