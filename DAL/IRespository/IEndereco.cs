using CrudEmpresas.DTO;

namespace CrudEmpresas.DAL.IRepository;

public interface IEndereco
{
    DTO_Resposta CadastrarEndereco(DTO_Endereco endereco);
    DTO_Resposta VisualizarEnderecos();
}