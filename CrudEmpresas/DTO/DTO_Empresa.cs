namespace CrudEmpresas.DTO;

public class DTO_Empresa
{
    public int id {get; set;}
    public string Firma {get;set;}
        
     public int ActividadeEconomicaId {get; set;}
       
    public string Logotipo {get; set;} 
    
    public DateTime Abertura {get; set;}
      
    public bool Ativo {get; set;}

}
