using System.Collections.Generic;

namespace CadastroDeClientes.Models
{
    public class SexoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
    public class SexoItens
    {
        public List<SexoModel> RetornaSexo()
        {
            var sexos = new List<SexoModel>();
            sexos.Add(new SexoModel { Nome = "Masculino", Id = 1 });
            sexos.Add(new SexoModel { Nome = "Feminino", Id = 2 });                 

            return sexos;
        }
    }
}
