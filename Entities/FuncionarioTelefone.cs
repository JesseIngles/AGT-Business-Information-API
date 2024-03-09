using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{

    [Table("funcionariotelefone")]
    public class funcionariotelefone
    {
        [Column("id")]
        public int id { get; set; }
        [Column("ddd")]
        public string ddd { get; set; }
        [Column("telefone")]
        public int telefone { get; set; }
    }
}