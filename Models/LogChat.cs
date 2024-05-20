using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrevisaoEcommerce.Models
{
    [Table("TB_LogsChat")]
    public class LogChat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogChat { get; set; }

        [Required(ErrorMessage = "O campo mensagem é obrigatório.")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "A data e hora do log são obrigatórias.")]
        public DateTime DataHora { get; set; }
    }
}
