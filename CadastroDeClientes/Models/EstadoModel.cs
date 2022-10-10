using System.Collections.Generic;

namespace CadastroDeClientes.Models
{
    public class EstadoModel
    {
        public int Id { get; set; }
        public string UF { get; set; }
    }

    public class EstadoItens
    {
        public List<EstadoModel> RetornaEstados()
        {
            var estados = new List<EstadoModel>();
            estados.Add(new EstadoModel { UF = "SP", Id = 1 });
            estados.Add(new EstadoModel { UF = "MG", Id = 2 });
            estados.Add(new EstadoModel { UF = "RJ", Id = 3 });
            estados.Add(new EstadoModel { UF = "ES", Id = 4 });

            return estados;
        }
    }
}
