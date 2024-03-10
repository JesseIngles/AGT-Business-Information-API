using CrudEmpresas.Controllers;
using CrudEmpresas.DAL.Database;
using CrudEmpresas.DAL.IRepository;
using CrudEmpresas.DTO;
using CrudEmpresas.Entities;
using CrudEmpresas.Services;
using FuzzySharp;

namespace CrudEmpresas.DAL.CRepository
{
    public class CRegime : IRegime
    {
        private readonly MyDbContext _db;
        public CRegime(MyDbContext context)
        {
            _db = context;
        }

        public Task<DTO_Resposta> CadastrarRegime()
        {
            throw new NotImplementedException();
        }
    }
}

       
                
      


                
                
           
         
    

                     
                         
                   
                                                                           
  


            
                      

       