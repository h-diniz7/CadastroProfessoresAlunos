using InstituicaoEnsino.Models;
using Microsoft.EntityFrameworkCore;

namespace InstituicaoEnsino.Data
{
    public class InstituicaoEnsinoContexto : DbContext
    {

        public InstituicaoEnsinoContexto(DbContextOptions<InstituicaoEnsinoContexto> options) : base(options)
        {

        }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

    }
}
