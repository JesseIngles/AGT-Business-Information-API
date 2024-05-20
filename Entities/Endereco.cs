using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{
    [Table("endereco")]
    public class Endereco
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("pais")]
        public string Pais {get;set;}
        [Column("provincia")]
        public string Provincia {get;set;}
        [Column("municipio")]
        public string Municipio {get;set;}
        [Column("bairro")]
        public string Bairro {get;set;}
        [Column("rua")]
        public string Rua {get;set;}
        [Column("ncasa")]
        public string Ncasa {get;set;}
    }
}