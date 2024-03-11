using CrudEmpresas.Entities;
namespace CrudEmpresas.DTO
{
    public class DTO_Empresa
    {
        public string Firma { get; set; }
        public string Nif { get; set; }
        public DateTime DataFundacao { get; set; }
        public IFormFile? Logotipo { get; set; }
        public bool Ativo { get; set; }
        public int SectorEconomicoId { get; set; }
        public int AtividadeEconomicaId { get; set; }
        public int TipoEmpresaId { get; set; }
        public int RegimeId { get; set; }
        public int EnderecoId { get; set; }
        public List<string>? Emails { get; set; }
        public List<string>? Telefones {get;set;}
    }
}