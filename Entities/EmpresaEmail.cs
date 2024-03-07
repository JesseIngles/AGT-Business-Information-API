using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("empresaemail")]
    public class EmpresaEmail
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("email")]
        public string Email {get;set;}
        [Column("empresaid")]
    }
}