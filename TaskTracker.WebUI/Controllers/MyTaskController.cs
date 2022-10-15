using Microsoft.AspNetCore.Mvc;
using TaskTracker.DAL.Model;
using TaskTracker.Logic.Implementations;

namespace TaskTracker.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class MyTaskController : Controller
    {
        private readonly MyTaskService _taskService;

        public MyTaskController(MyTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var response = _taskService.GetTaskById(id);
            return Ok(response);
        }

        [HttpPost("{projectId}")]
        public IActionResult CreateTask(int projectId, string taskName, string taskDescritption,
            DateTime startDate, DateTime finishDate, MyTaskStatus status, int priority)
        {
            _taskService.CreateTask(projectId, taskName, taskDescritption,
                startDate, finishDate, status, priority);
            return Ok();
        }

        [HttpPut("UpdateItem")]
        public IActionResult UpdateTask(int id, string taskName, string taskDescritption,
            DateTime startDate, DateTime finishDate, MyTaskStatus status, int priority)
        {
            _taskService.UpdateTask(id, taskName, taskDescritption, startDate, finishDate,
                status, priority);
            return Ok();
        }

        [HttpDelete("DeletebyId")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
