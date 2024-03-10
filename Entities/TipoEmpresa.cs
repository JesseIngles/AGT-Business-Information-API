using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{

    [Table("tipoEmpresa")]
    public class  TipoEmpresa
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("nome")]
        public string Nome{get;set;}
    }
}