using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudEmpresas.Entities
{
  [Table("Contribuinte")]
public class Contribuinte
{
   [Column ("id")]
   public int id {get; set;}

   [Column ("firma")]
  public string Firma{get; set;}
  
   [Column("Nif")]
   public string Nif {get; set;}

   [Column("Regimeid")]
    public int Regimid {get; set;}
}
}