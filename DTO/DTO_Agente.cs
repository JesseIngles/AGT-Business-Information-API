using CrudEmpresas.Entities;
namespace CrudEmpresas.DTO
{
    public class DTO_Agente
    {
        public string Nome { get; set; }
        public string Nif { get; set; }

        public string senha  { get; set; }
        public bool isAdmin { get; set; }
        public bool Ativo { get; set; }
        
           }

     }
