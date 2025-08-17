using System.ComponentModel.DataAnnotations;

namespace InstituicaoEnsino.Models
{
    public class Aluno
    {

        public int AlunoId { get; set; }

        
        [Required(ErrorMessage = "Nome do aluno é obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Mensalidade do aluno é obrigatória!")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Mensalidade { get; set; }

        [Required(ErrorMessage = "DataVencimento do aluno é obrigatória!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }
        public int ProfessorId { get; set; }
    }
}
