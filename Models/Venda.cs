using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Categoria inválida")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage=" Funcionário não encontrado")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
       
        [Required(ErrorMessage="Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Categoria inválida")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
