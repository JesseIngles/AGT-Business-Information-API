namespace CrudEmpresas.Services;

public class ConverterImagemService
{
    public static string ConverterParaBase64(IFormFile foto)
    {
        string resposta = string.Empty;
        MemoryStream ms = new MemoryStream();
        foto.CopyTo(ms);
        byte[] imageBytes = ms.ToArray();
        resposta = Convert.ToBase64String(imageBytes);
        return resposta;
    }
}