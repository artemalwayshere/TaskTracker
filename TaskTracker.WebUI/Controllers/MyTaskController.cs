using Microsoft.AspNetCore.Mvc;
using TaskTracker.Logic.Implementations;

namespace TaskTracker.WebUI.Controllers
{
    [Route("[controller]")]
    public class MyTaskController : Controller
    {
        private readonly MyTaskService _taskService;

        public MyTaskController(MyTaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> CreateTask()
        {
            return View();
        }
    }
}
