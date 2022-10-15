using Microsoft.AspNetCore.Mvc;
using TaskTracker.DAL.Model;
using TaskTracker.Logic.Implementations;
using TaskTracker.Logic.Interfaces;

namespace TaskTracker.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;
        private readonly ISortService _sortService;


        public ProjectController(ProjectService projectService, SortService sortService)
        {
            _projectService = projectService;
            _sortService = sortService;
        }
        #region CRUD Action

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

        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(string projectName, string projectDescription,
            DateTime startDate, DateTime finishDate, ProjectStatus projectStatus, int priority)
        {
            _projectService.CreateProject(projectName, projectDescription,
                startDate, finishDate, projectStatus, priority);
            return Ok();
        }

        [HttpPut("UpdateProject")]
        public IActionResult UpdateProject(string projectName, string projectDescription,
            DateTime startDate, DateTime finishDate, ProjectStatus projectStatus, int priority, int id)
        {
            _projectService.UpdateProject(projectName, projectDescription, startDate,
                finishDate, projectStatus, priority, id);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }
        #endregion

        #region SortAction

        [HttpGet("SortByFinishDate")]
        public IActionResult SortByFinishDate()
        {
            var pjs = _projectService.GetAllProjects();
            return Ok();
        }

        [HttpGet("sortByName")]
        public IActionResult SortByName()
        {
            var pjs = _projectService.GetAllProjects();
            var result = _sortService.SortByName(pjs);
            return Ok(result);
        }


        [HttpGet("SortByPriority")]
        public IActionResult SortByPriority()
        {
            _sortService.SortByPriority(_projectService.GetAllProjects());
            return Ok();
        }

        [HttpGet("SortByStartDate")]
        public IActionResult SortByStartDate(IEnumerable<Project> spurceProjects)
        {
            _sortService.SortByStartDate(_projectService.GetAllProjects());
            return Ok();
        }

        [HttpGet("SortByStatus")]
        public IActionResult SortByStatus(IEnumerable<Project> spurceProjects)
        {
            _sortService.SortByStatus(_projectService.GetAllProjects());
            return Ok();
        }
        #endregion
    }
}
