using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;

namespace CrudEmpresas.DAL.CRepository
{
    public class CEmpresa : IEmpresa
    {
        private readonly MyDbContext _db; 
        public CEmpresa(MyDbContext context)
        {
            _db = context;
        }
        public async Task<DTO_Resposta> CadastrarEmpresa(Empresa empresa)
        {
            DTO_Resposta resposta = new DTO_Resposta();
            try
            {
                if(empresa == null)
                {
                    resposta.mensagem = "Dados inválidos";
                    return resposta;
                }
                await _db.TbEmpresa.AddAsync(empresa);
                await _db.SaveChangesAsync();
                resposta.mensagem = "Sucesso";
            }catch(Exception ex)
            {
                resposta.mensagem = ex.ToString();
            }
            return resposta;
        }
    }
}