using InstituicaoEnsino.Models;
using InstituicaoEnsino.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InstituicaoEnsino.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessoresController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            List<Professor> professores = await _professorRepositorio.BuscarDados();

            professores = professores.OrderBy(p => p.ProfessorId).ToList();

            return View(professores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Professor professor)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(professor);
                }

                await _professorRepositorio.Adicionar(professor);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = $"Ocorreu um erro ao cadastrar o usuário {ex.Message.ToString()}";
             
                return View();
            }


        }

    }
}
