using System.ComponentModel.DataAnnotations.Schema;


namespace CrudEmpresas.Entities
{

    [Table("sectoreconomico")]
    public class SectorEconomico
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
    }
}