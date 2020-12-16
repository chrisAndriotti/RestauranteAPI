using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Máximo 60 caracteres")]
        [MinLength(4, ErrorMessage="Mínimo 4 caracteres")]
        public string Nome { get; set; }

    }
}
