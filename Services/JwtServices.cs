namespace CrudEmpresas.Services;

public class JwtService
{
    private IConfiguration _config;
    public JwtService(IConfiguration configuration)
    {
        _config = configuration;
    }
    public string GerarTokenAgente()
    {
        string resposta = string.Empty;
        
        return resposta;
    }
}