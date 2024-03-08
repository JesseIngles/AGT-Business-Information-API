 using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("actividadeeconomica")]
    public class ActividadeEconomica 
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string Nome {get;set;}
    }
}