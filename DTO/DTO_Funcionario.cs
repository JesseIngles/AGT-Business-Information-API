using CrudEmpresas.Entities;
namespace CrudEmpresas.DTO
{
<<<<<<< HEAD
    public class DTO_Funcionario
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Nif { get; set; }
        public string CV  { get; set; }
        public string Foto { get; set; }
        public bool Ativo { get; set; }
        public List<string> Emails {get;set;}
        public List<string> Telefones {get;set;}

    }
=======
public class DTO_Funcionario
{
       public int Id {get;set;}
        
        public string PrimeiroNome {get;set;}
        
        public string UltimoNome {get;set;}
        
        public string Nif {get;set;}
        
        public string CV {get;set;}
        
        public string Foto {get;set;}
}

>>>>>>> Jesse
}