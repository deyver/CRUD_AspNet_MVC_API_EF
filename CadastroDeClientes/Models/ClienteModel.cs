using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDeClientes.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente.")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o endereço do cliente.")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [MaxLength(15, ErrorMessage = "O tamanho máximo é de 14 caracteres.")]
        [MinLength(14, ErrorMessage = "CPF Incompleto")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do cliente.")]
        public string DataNascimento { get; set; }


        [Required(ErrorMessage = "Digite o estado do cliente.")]
        public int IdEstado { get; set; }

        [NotMapped]
        public string SiglaUF { get; set; }


        [Required(ErrorMessage = "Digite a cidade do cliente.")]
        public int IdCidade { get; set; }      

        [NotMapped]
        public string NomeCidade { get; set; }


        [Required(ErrorMessage = "Escolha o sexo do cliente.")]       
        public string Sexo { get; set; }
    }
}
