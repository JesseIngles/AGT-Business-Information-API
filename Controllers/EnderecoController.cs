using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmpresas.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class EnderecoController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;
    private readonly IEndereco _endereco;
    public EnderecoController(ILogger<EmpresaController> logger, IEndereco endereco)
    {
        _logger = logger;
        _endereco = endereco;
    }

    [HttpPost("AdicionarEndereco")]
    public DTO_Resposta AdicionarEndereco(DTO_Endereco endereco)
    {
        var resposta = _endereco.CadastrarEndereco(endereco);
        return resposta;
    }

    [HttpGet("Visualizarenderecos")]
    public DTO_Resposta VisualizarEnderecos()
    {
        var resposta = _endereco.VisualizarEnderecos();
        return resposta;
    }
    
}
