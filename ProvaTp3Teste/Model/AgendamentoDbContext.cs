using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProvaTp3Teste.Model
{
    public class AgendamentoDbContext : DbContext
    {
        public AgendamentoDbContext(DbContextOptions<AgendamentoDbContext> options) : base(options)
        {
        }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Andar> Andares { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
