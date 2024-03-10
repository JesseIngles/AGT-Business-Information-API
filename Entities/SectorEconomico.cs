using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{

    [Table("sectorEconomico")]
    public class SectorEconomico
    {
        [Column("id")]
        public int id { get; set; }
        [Column("nome")]
        public string nome { get; set; }
    }
}