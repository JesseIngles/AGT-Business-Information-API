using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("empresatelefone")]
    public class EmpresaTelefone
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("telefone")]
        public string Telefone {get;set;}
        [Column("empresaid")]
        public int EmpresaId {get;set;}
    }
}