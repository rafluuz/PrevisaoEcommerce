using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrevisaoEcommerce.Models
{
    [Table("TB_DadosMercado")]
    public class DadosMercado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDadosMerc { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da empresa deve ter entre 3 e 100 caracteres.")]
        public string NomeEmpresa { get; set; }

        [Range(1900, 9999, ErrorMessage = "Por favor, insira um ano válido.")]
        public int AnoPrevisao { get; set; }

    }
}
