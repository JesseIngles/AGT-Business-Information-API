using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{

    [Table("tipoEmpresa")]
    public class  tipoEmpresa
    {
        [Column("id")]
        public int id {get;set;}
        [Column("nome")]
        public string nome{get;set;}
    }
}