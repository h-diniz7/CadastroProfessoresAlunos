using InstituicaoEnsino.Models;
using InstituicaoEnsino.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace InstituicaoEnsino.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly IProfessorRepositorio _professorRepositorio;

        public AlunosController(IAlunoRepositorio alunoRepositorio, IConfiguration configuration, IMemoryCache memoryCache, IProfessorRepositorio professorRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _configuration = configuration;
            _memoryCache = memoryCache;
            _professorRepositorio = professorRepositorio;
        }

        public async Task<IActionResult> Index(int Id)
        {

            List<Professor> professores = await _professorRepositorio.BuscarDados();

            Professor? professor = professores.FirstOrDefault(p => p.ProfessorId == Id);

            List<Aluno> aluno = await _alunoRepositorio.BuscarDados();

            aluno = aluno.Where(p => p.ProfessorId == Id).ToList();

            ViewBag.ProfessorId = professor?.ProfessorId;

            ViewBag.ProfessorNome = professor?.Nome;

            return View(aluno);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int Id)
        {
            List<Aluno> alunos = await _alunoRepositorio.BuscarDados();

            Aluno? aluno = alunos.FirstOrDefault(p => p.AlunoId == Id);

            if (aluno == null) return NotFound();

            await _alunoRepositorio.Deletar(aluno);

            return Ok();
        }

        public IActionResult Importar(int professorId)
        {
            ViewBag.ProfessorId = professorId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Importar(IFormFile arquivo, int professorId)
        {
            try
            {

                if (arquivo != null && arquivo.Length > 0 && arquivo.FileName.ToLower().Contains(".txt"))
                {
                    var restricaoConfiguracao = _configuration["RestricaoImportacaoSegundos"];
                    int restricao = 0;                    

                    if (!string.IsNullOrEmpty(restricaoConfiguracao))
                    {
                         restricao = int.Parse(restricaoConfiguracao);
                    }                    

                    string chaveCache = $"Importacao_{professorId}";

                    if (_memoryCache.TryGetValue(chaveCache, out DateTime ultimoImport))
                    {
                        int tempoPassado = Convert.ToInt32((DateTime.Now - ultimoImport).TotalSeconds);

                        if (tempoPassado < restricao)
                        {

                            TempData["Mensagem"] = $"A importação está bloqueada por mais {restricao - tempoPassado} segundos.";

                            ViewBag.ProfessorId = professorId;

                            return View();
                        }

                    }

                    using (var reader = new StreamReader(arquivo.OpenReadStream()))
                    {
                        string linha;

                        while ((linha = reader.ReadLine()) != null)
                        {
                            var dados = linha.Split("||");
                            var aluno = new Aluno
                            {
                                Nome = dados[0],
                                Mensalidade = decimal.Parse(dados[1]),
                                DataVencimento = DateTime.Parse(dados[2]),
                                ProfessorId = professorId
                            };

                            await _alunoRepositorio.Adicionar(aluno);
                        }



                    }

                    _memoryCache.Set(chaveCache, DateTime.Now);

                }
                else
                {
                    ViewBag.ProfessorId = professorId;

                    TempData["Mensagem"] = "Não foi possível ler o arquivo.";

                    return View();
                }

            }
            catch (Exception)
            {

                ViewBag.ProfessorId = professorId;

                TempData["Mensagem"] = "Ocorreu um erro ao tentar importar o arquivo.";

                return View();
            }

            return RedirectToAction("Index", new { Id = professorId });
        }


    }
}
