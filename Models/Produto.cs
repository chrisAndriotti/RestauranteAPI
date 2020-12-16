using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Máximo 60 caracteres")]
        [MinLength(4, ErrorMessage="Mínimo 4 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(0.5, double.MaxValue, ErrorMessage="Preço deve ser maior que zero")]
        public double Preco { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Categoria inválida")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Fornecedor inválido")]
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

    }
}
