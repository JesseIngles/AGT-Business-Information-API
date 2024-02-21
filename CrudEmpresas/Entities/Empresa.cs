using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{
    [Table("empresa")]
    public class Empresa
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("firma")]
        public string Firma {get;set;}
        [Column("actividadeEconomicaId")]
        public int ActividadeEconomicaId {get; set;}
        [Column("logotipo")]
        public string Logotipo {get; set;}
        [Column("abertura")]
        public DateOnly Abertura {get; set;}
        [Column("ativo")]
        public bool Ativo {get; set;}
    }
}