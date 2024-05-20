using CrudEmpresas.Entities;
namespace CrudEmpresas.DTO
{
    public class DTO_Agente
    {
        public string Nome { get; set; }
        public string Nif { get; set; }
        public string senha  { get; set; }
        public bool isAdmin { get; set; }
        public List<string>? Emails {get;set;}
        public List<string>? Telefones {get;set;}
    }
}
