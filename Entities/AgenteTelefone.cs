using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("agentelefone")]
    public class AgenteTelefone
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("telefone")]
        public string Telefone {get;set;}
        [Column("agenteid")]
        public int AgenteId {get;set;}
    }
}