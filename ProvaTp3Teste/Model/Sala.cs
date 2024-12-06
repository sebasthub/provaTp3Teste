using System.ComponentModel.DataAnnotations;

namespace ProvaTp3Teste.Model
{
    public class Sala
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(0, 16, ErrorMessage = "De 1 a 16, inicia na abertura as 8 e termina no fexamento as 22")]
        public int HorarioDisponivel { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int AndarId { get; set; }
        public Andar Andar { get; set; }
        public int? CursoId { get; set; } = null;
        public Curso Curso { get; set; } = null;

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
