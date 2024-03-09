using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{
    [Table("endereco")]
    public class endereco{
        [Column("id")]
        public int id {get;set;}
        [Column("pais")]
        public string pais {get;set;}
        [Column("provincia")]
        public int provincia {get;set;}
        [Column("municipio")]
        public string municipio {get;set;}
        [Column("bairro")]
        public int bairro {get;set;}
        [Column("rua")]
        public string rua {get;set;}
        [Column("ncasa")]
        public int ncasa {get;set;}
    }
}