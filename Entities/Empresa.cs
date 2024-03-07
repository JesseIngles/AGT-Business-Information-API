using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("empresa")]
    public class Empresa
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("firma")]
        public string Firma { get; set; }
        [Column("nif")]
        public string Nif { get; set; }
        [Column("datafundacao")]
        public DateTime DataFundacao { get; set; }
        [Column("logotipo")]
        public string Logotipo { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }
        [Column("sectoreconomicoid")]
        public int SectorEconomicoId { get; set; }
        [Column("atividadeeconomicaId")]
        public int AtividadeEconomicaId { get; set; }
        [Column("tipoempresaid")]
        public int TipoEmpresaId { get; set; }
        [Column("regimeid")]
        public int RegimeId { get; set; }
        [Column("enderecoid")]
        public int EnderecoId { get; set; }

    }
}