 using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{
    [Table("agente")]
    public class Agente
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string Nome {get;set;}

        [Column("senha")]
        public string Senha {get;set;}
        [Column("nif")]
        public string Nif {get;set;}

        [Column("isAdmin")]
        public bool IsAdmin {get;set;}

        [Column("Ativo")]
        public bool Ativo {get;set;} 
    }  
}
    
