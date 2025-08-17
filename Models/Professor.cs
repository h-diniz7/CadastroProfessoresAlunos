using System.ComponentModel.DataAnnotations;

namespace InstituicaoEnsino.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Nome do professor é obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }
    }
}
