using Microsoft.EntityFrameworkCore;
using InstituicaoEnsino.Data;
using InstituicaoEnsino.Models;

namespace InstituicaoEnsino.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly InstituicaoEnsinoContexto _InstituicaoEnsinoContexto;
        public ProfessorRepositorio(InstituicaoEnsinoContexto instituicaoEnsinoContexto)
        {
            _InstituicaoEnsinoContexto = instituicaoEnsinoContexto;
        }

        public async Task<Professor> Adicionar(Professor professor)
        {
            _InstituicaoEnsinoContexto.Professores.Add(professor);
            await _InstituicaoEnsinoContexto.SaveChangesAsync();

            return professor;
        }

        public async Task<List<Professor>> BuscarDados()
        {
            return await _InstituicaoEnsinoContexto.Professores.ToListAsync();
        }
    }
}
