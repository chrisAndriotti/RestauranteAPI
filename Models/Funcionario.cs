using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Máximo 60 caracteres")]
        [MinLength(4, ErrorMessage="Mínimo 4 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(11, ErrorMessage="Máximo 11 caracteres")]
        [MinLength(10, ErrorMessage="Máximo 10 caracteres")]
        public string Telefone { get; set; } 

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Cargo inválido")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set;}

    }
}
