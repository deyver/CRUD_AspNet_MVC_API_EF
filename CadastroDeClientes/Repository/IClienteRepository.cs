using CadastroDeClientes.Models;
using System.Collections.Generic;

namespace CadastroDeClientes.Repository
{
    public interface IClienteRepository
    {
        ClienteModel ListarId(int id);
        List<ClienteModel> BuscarTodos();
        ClienteModel Adicionar(ClienteModel cliente);
        ClienteModel Atualizar(ClienteModel cliente);  
        bool Apagar(int id);
    }
}
