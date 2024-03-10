using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("empresafuncionario")]
    public class EmpresaFuncionario
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("empresaid")]
        public int EmpresaId {get;set;}
        [Column("funcionarioid")]
        public int FuncionarioId {get;set;}
    
        [Column("cargoid")]
        public int CargoId {get;set;}
    }
}