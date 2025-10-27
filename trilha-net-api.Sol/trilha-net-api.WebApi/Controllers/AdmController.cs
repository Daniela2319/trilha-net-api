using Microsoft.AspNetCore.Mvc;
using trilha_net_api.Models;
using trilha_net_api.Services;

namespace trilha_net_api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdmController : ControllerBase
    {
        #region Propriedades
            private readonly IAdministradorService _admService;
        #endregion

        #region Constructor
            public AdmController(IAdministradorService admService)
            {
                _admService = admService;
            }
        #endregion

        #region Post
            [HttpPost]
            public IActionResult register(Administrador administrador)
            {
                if (administrador == null)
                    return BadRequest("Dados inválidos");

                var id = _admService.Register(administrador.Email, administrador.Senha, administrador.Perfil);
                return CreatedAtAction(nameof(GetById), new { id = id }, administrador);
            }
        #endregion

        #region Get
            [HttpGet]
            public IActionResult GetAll()
            {
                var adms = _admService.GetAll();
                if (adms == null || !adms.Any())
                    return NotFound("Nenhuma tarefa encontrada");
                return Ok(adms);
            }
        #endregion

        #region Get Id
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var adm = _admService.GetById(id);
                if (adm == null)
                    return NotFound("Tarefa não encontrada");

                return Ok(adm);
            }
        #endregion
    }
}
