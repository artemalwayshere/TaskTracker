using Microsoft.AspNetCore.Mvc;
using TaskTracker.DAL.Model;
using TaskTracker.Logic.Implementations;

namespace TaskTracker.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;


        public ProjectController(ProjectService projectService, MyTaskService myTaskService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            return Ok(project);
        }

        [HttpPost("{CreateProject}")]
        public async Task<IActionResult> CreateProject(string projectName, string projectDescription,
            DateTime startDate, DateTime finishDate, ProjectStatus projectStatus, int priority)
        {
            _projectService.CreateProject(projectName, projectDescription,
                startDate, finishDate, projectStatus, priority);
            return Ok();
        }

        [HttpPut("{UpdateProject}")]
        public IActionResult UpdateProject(string projectName, string projectDescription,
            DateTime startDate, DateTime finishDate, ProjectStatus projectStatus, int priority, int id)
        {
            _projectService.UpdateProject(projectName, projectDescription, startDate,
                finishDate, projectStatus, priority, id);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }
    }
}
