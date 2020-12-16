using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Máximo 60 caracteres")]
        [MinLength(4, ErrorMessage="Mínimo 4 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage="Valor inválido")]
        public double Salario { get; set; }

    }
}
