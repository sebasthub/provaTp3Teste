using System.ComponentModel.DataAnnotations;

namespace ProvaTp3Teste.Model
{
    public class Professor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Indentificador { get; set; }
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
