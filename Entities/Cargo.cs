using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{
    [Table("cargo")]
    public class Cargo
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string Nome {get;set;}
    }
}