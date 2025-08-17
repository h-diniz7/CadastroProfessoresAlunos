using InstituicaoEnsino.Models;

namespace InstituicaoEnsino.Repositorio
{
    public interface IProfessorRepositorio
    {
        Task<List<Professor>> BuscarDados();

        Task<Professor> Adicionar(Professor professor);

    }
}
