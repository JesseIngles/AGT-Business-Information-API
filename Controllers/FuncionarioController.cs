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
    
}
