using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trilha_net_api.Models;
using trilha_net_api.Services;

namespace trilha_net_api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        #region Propriedades
            private readonly ITaskService _taskService;
        #endregion

        #region Constructor
        public TaskController(ITaskService taskService)
            {
                _taskService = taskService;
            }
        #endregion

        #region Post
        [HttpPost]
            public IActionResult register(TaskA task)
            {
                if (task == null)
                    return BadRequest("Dados inválidos");

                var id = _taskService.Register(task.Title, task.Description, task.DueDate, task.Status);
                return CreatedAtAction(nameof(GetById), new { id = id }, task);
            }
        #endregion

        #region Get Id
        [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var task = _taskService.GetById(id);
                if (task == null)
                    return NotFound("Tarefa não encontrada");

                return Ok(task);
            }
        #endregion

        #region Get
        [HttpGet]
            public IActionResult GetAll()
            {
                var tasks = _taskService.GetAll();
                if (tasks == null || !tasks.Any())
                    return NotFound("Nenhuma tarefa encontrada");
                return Ok(tasks);
            }
        #endregion

        #region Put
        [HttpPut("{id}")]
            public IActionResult Update(int id, TaskA task)
            {
                if (task == null || id != task.Id)
                    return BadRequest("Dados inválidos");
                var updated = _taskService.Update(id, task.Title, task.Description, task.DueDate, task.Status);
                if (!updated)
                    return NotFound("Tarefa não encontrada");
                return NoContent();
            }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var deleted = _taskService.Delete(id);
                if (!deleted)
                    return NotFound("Tarefa não encontrada");
                return NoContent();
            }
        #endregion

        #region ObterTitulo
        [HttpGet("title/{title}")]
            public IActionResult GetByTitle(string title)
            {
                var tasks = _taskService.GetAll().Where(t => t.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                if (tasks == null || !tasks.Any())
                    return NotFound("Nenhuma tarefa encontrada com o título especificado");
                return Ok(tasks);
            }
        #endregion

        #region ObterStatus
        [HttpGet("status/{status}")]
            public IActionResult GetByStatus(EnumStatusTask status)
            {
                var tasks = _taskService.GetAll().Where(t => t.Status == status).ToList();
                if (tasks == null || !tasks.Any())
                    return NotFound("Nenhuma tarefa encontrada com o status especificado");
                return Ok(tasks);
            }
        #endregion

        #region ObterData
        [HttpGet("dueDate/{dueDate}")]
            public IActionResult GetByDueDate(DateTime dueDate)
            {
                var tasks = _taskService.GetAll().Where(t => t.DueDate.Date == dueDate.Date).ToList();
                if (tasks == null || !tasks.Any())
                    return NotFound("Nenhuma tarefa encontrada com a data especificada");
                return Ok(tasks);
            }
        #endregion
    }
}
