using CrudEmpresas.Entities;
namespace CrudEmpresas.DTO
{
    public class DTO_Endereco
    {
        public string pais {get;set;}
        public int provincia {get;set;}
        public string municipio {get;set;}
        public int bairro {get;set;}
        public string rua {get;set;}
        public int ncasa {get;set;}
    }
}