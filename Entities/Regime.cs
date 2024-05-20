 using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("regime")]
    public class Regime
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string Nome {get;set;}
    }
}