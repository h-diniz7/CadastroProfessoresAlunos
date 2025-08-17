using InstituicaoEnsino.Models;

namespace InstituicaoEnsino.Repositorio
{
    public interface IAlunoRepositorio
    {
        Task<List<Aluno>> BuscarDados();
        Task<Aluno> Adicionar(Aluno aluno);

        Task<bool> Deletar(Aluno aluno);
    }
}
