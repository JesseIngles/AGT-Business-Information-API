using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

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
    [HttpPost(Name = "AdicionarFuncionario")]
    public async Task<DTO_Resposta>  CadastrarFuncionario(DTO_Funcionario funcionario)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _funcionario.CadastrarFuncionario(funcionario);
        return resposta;
    }
    
    [HttpPut(Name = "AtualizarFuncionario")]
    public async Task<DTO_Resposta> AtualizarFuncionario(DTO_Funcionario funcionario, int id)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await _funcionario.AtualizarFuncionario(funcionario, id);
        return resposta;
    }
    [AllowAnonymous]
    [HttpGet(Name = "PesquisarFuncionario")]
    public async Task<DTO_Resposta> PesquisarFuncionarioAsync(string consulta)
    {
        DTO_Resposta resposta = new DTO_Resposta();
        resposta = await  _funcionario.PesquisarFuncionario(consulta);
        return resposta;
    }
    
}

