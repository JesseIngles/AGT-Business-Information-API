using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("agenteemail")]
    public class AgenteEmail
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("email")]
        public string Email {get;set;}
        [Column("agenteemail")]
        public int AgenteId {get;set;}
    }
}