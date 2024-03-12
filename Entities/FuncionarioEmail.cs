 using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("funcionarioemail")]
    public class FuncionarioEmail
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("email")]
        public string Email {get;set;}
        [Column("funcionarioid")]
        public int FuncionarioId {get;set;}
    }
}