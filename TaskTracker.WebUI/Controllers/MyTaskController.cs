using Microsoft.AspNetCore.Mvc;
using TaskTracker.DAL.Model;
using TaskTracker.Logic.Implementations;

namespace TaskTracker.WebUI.Controllers
{
    /// <summary>
    /// Controller to work task API
    /// </summary>
    [Route("api/[controller]")]
    public class MyTaskController : Controller
    {
        private readonly MyTaskService _taskService;

        public MyTaskController(MyTaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get task by id from any project
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Task</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var response = _taskService.GetTaskById(id);
            return Ok(response);
        }

        /// <summary>
        /// Create task by project id
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="taskName">Task name</param>
        /// <param name="taskDescritption">Task description</param>
        /// <param name="startDate">Task start date</param>
        /// <param name="finishDate">Task finish date</param>
        /// <param name="status">Task status</param>
        /// <param name="priority">Task priority</param>
        /// <returns>No content</returns>
        [HttpPost("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask(int projectId, string taskName, string taskDescritption,
            DateTime startDate, DateTime finishDate, MyTaskStatus status, int priority)
        {
            _taskService.CreateTask(projectId, taskName, taskDescritption,
                startDate, finishDate, status, priority);
            return Ok();
        }

        /// <summary>
        /// Update task by id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="taskName">Task name</param>
        /// <param name="taskDescritption">Task description</param>
        /// <param name="startDate">Task start date</param>
        /// <param name="finishDate">Task finish date</param>
        /// <param name="status">Task status</param>
        /// <param name="priority">Task priority</param>
        /// <returns>No content</returns>
        [HttpPut("UpdateItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTask(int id, string taskName, string taskDescritption,
            DateTime startDate, DateTime finishDate, MyTaskStatus status, int priority)
        {
            _taskService.UpdateTask(id, taskName, taskDescritption, startDate, finishDate,
                status, priority);
            return Ok();
        }

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id">ЕTaask id</param>
        /// <returns></returns>
        [HttpDelete("DeletebyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
