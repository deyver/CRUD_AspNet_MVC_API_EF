using CadastroDeClientes.Data;
using CadastroDeClientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeClientes.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ClienteModel ListarId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }
        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarId(cliente.Id);

            if (clienteDB == null) throw new System.Exception("Houve um erro na atualização do cliente.");

            clienteDB.Nome = cliente.Nome;
            clienteDB.CPF = cliente.CPF;
            clienteDB.DataNascimento = cliente.DataNascimento;
            clienteDB.Endereco = cliente.Endereco;
            clienteDB.IdCidade = cliente.IdCidade;
            clienteDB.IdEstado = cliente.IdEstado;
            clienteDB.Sexo = cliente.Sexo;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = ListarId(id);

            if (clienteDB == null) throw new System.Exception("Houve um erro na deleção do cliente.");
            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
