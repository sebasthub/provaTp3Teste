using System.ComponentModel.DataAnnotations;

namespace ProvaTp3Teste.Model
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public String Nome { get; set; }

        public ICollection<Sala> Sala { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}
