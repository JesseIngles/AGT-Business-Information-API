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
    private static string UploadFoto(string foto)
    {
        if (foto != null && foto != "")
        {

            Guid guid = Guid.NewGuid();
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fullPath = Path.Combine(pathToSave, $"{guid}.jpg");
                // var dbPath = Path.Combine(folderName, "fileName.jpg");
            string newOdd = foto.Replace("data:image/jpeg;base64,", "").Trim();
            newOdd = newOdd.Replace("data:image/png;base64,", "").Trim();
            var bytes = Convert.FromBase64String(newOdd);

            using (var imageFile = new FileStream(fullPath, FileMode.Create))
            {
            imageFile.Write(bytes, 0, bytes.Length);
            imageFile.Flush();
            }
            return $"/files/images/{guid}.jpg";
        }
        return null;
    }

}