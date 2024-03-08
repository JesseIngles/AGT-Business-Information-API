using System.ComponentModel.DataAnnotations.Schema;

namespace CrudEmpresas.Entities
{

    [Table("empresafuncionario")]
    public class EmpresaFuncionario
    {
        [Column("id")]
        public int Id {get;set;}
        [Column("empresaid")]
        public string EmpresaId {get;set;}
        [Column("funcionarioid")]
        public string FuncionarioId {get;set;}
    
        [Column("cargoid")]
        public string CargoId {get;set;}
    }
}