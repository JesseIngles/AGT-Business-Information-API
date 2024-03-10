using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("funcionario")]
    public class Funcionario
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("primeironome")]
        public string PrimeiroNome {get;set;}
        [Column("ultimonome")]
        public string UltimoNome {get;set;}
        [Column("nif")]
        public string Nif {get;set;}
        [Column("cv")]
        public string CV {get;set;}
        [Column("foto")]
        public string Foto {get;set;}
    }
}
    
