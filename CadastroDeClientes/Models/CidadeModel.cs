using System.Collections.Generic;

namespace CadastroDeClientes.Models
{
    public class CidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
    public class CidadeItens
    {
        public List<CidadeModel> RetornaCidades()
        {
            var cidades = new List<CidadeModel>();
            cidades.Add(new CidadeModel { Nome = "São Paulo", Id = 1 });
            cidades.Add(new CidadeModel { Nome = "Guarulhos", Id = 2 });
            cidades.Add(new CidadeModel { Nome = "São José dos Campos", Id = 3 });
            cidades.Add(new CidadeModel { Nome = "Bauru", Id = 4 });          

            return cidades;
        }
    }
}
