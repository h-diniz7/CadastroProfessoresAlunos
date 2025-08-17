using Microsoft.EntityFrameworkCore;
using InstituicaoEnsino.Data;
using InstituicaoEnsino.Models;
using System.Threading.Tasks;

namespace InstituicaoEnsino.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly InstituicaoEnsinoContexto _instituicaoEnsinoContexto;

        public AlunoRepositorio(InstituicaoEnsinoContexto instituicaoEnsinoContexto)
        {
            _instituicaoEnsinoContexto = instituicaoEnsinoContexto;
        }

        public async Task<List<Aluno>> BuscarDados()
        {
            return await _instituicaoEnsinoContexto.Alunos.ToListAsync();
        }


        public async Task<Aluno> Adicionar(Aluno aluno)
        {
            _instituicaoEnsinoContexto.Alunos.Add(aluno);
           await _instituicaoEnsinoContexto.SaveChangesAsync();

            return aluno;
        }

        public async Task<bool> Deletar(Aluno aluno)
        {
            _instituicaoEnsinoContexto.Alunos.Remove(aluno);
            await _instituicaoEnsinoContexto.SaveChangesAsync();

            return true;
        }
    }
}
