using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{
    [Table("funcionariotelefone")]
    public class FuncionarioTelefone
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("telefone")]
        public string Telefone { get; set; }
        [Column("funcionarioid")]
        public int FuncionarioId {get;set;}
    }
}