using CrudEmpresas.Entities;
namespace CrudEmpresas.DTO
{
    public class DTO_SectorEconomico
    {
        public string Nome { get; set; }
        
        public List<string> Emails {get;set;}
        public List<string> Telefones {get;set;}

    }
}
