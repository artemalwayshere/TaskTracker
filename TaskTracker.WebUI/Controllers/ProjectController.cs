using Microsoft.AspNetCore.Mvc;
using TaskTracker.DAL.Model;
using TaskTracker.Logic.Implementations;
using TaskTracker.Logic.Interfaces;

namespace TaskTracker.WebUI.Controllers
{
    /// <summary>
    /// Controller to work project api.
    /// </summary>
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

        /// <summary>
        /// Action to get all projects.
        /// </summary>
        /// <returns>project list</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllProject()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        /// <summary>
        /// Get project by id
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns> Project by id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            return Ok(project);
        }

        /// <summary>
        /// Create project
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <param name="projectDescription">Project description</param>
        /// <param name="startDate">Project start date</param>
        /// <param name="finishDate">Project finish date</param>
        /// <param name="projectStatus">Project status</param>
        /// <param name="priority">Project priority</param>
        /// <returns>No conent</returns>
        [HttpPost("CreateProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProject(string projectName, string projectDescription,
            DateTime startDate, DateTime finishDate, ProjectStatus projectStatus, int priority)
        {
            _projectService.CreateProject(projectName, projectDescription,
                startDate, finishDate, projectStatus, priority);
            return Ok();
        }

        /// <summary>
        /// Update Project by id
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <param name="projectDescription">Project description</param>
        /// <param name="startDate">Project start date</param>
        /// <param name="finishDate">Project finish date</param>
        /// <param name="projectStatus">Project status</param>
        /// <param name="priority">Project priority</param>
        /// <param name="id">Poject id</param>
        /// <returns>No contetnt</returns>
        [HttpPut("UpdateProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProject(string projectName, string projectDescription,
            DateTime startDate, DateTime finishDate, ProjectStatus projectStatus, int priority, int id)
        {
            _projectService.UpdateProject(projectName, projectDescription, startDate,
                finishDate, projectStatus, priority, id);
            return Ok();
        }

        /// <summary>
        /// Delete project by id
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>No content</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }
        #endregion

        #region SortAction

        /// <summary>
        /// Get sorted list of project by finish date
        /// </summary>
        /// <returns>Returns sorted list by finish date</returns>
        [HttpGet("SortByFinishDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SortByFinishDate()
        {
            var pjs = _projectService.GetAllProjects();
            var result = _sortService.SortByFinishDate(pjs);
            return Ok(result);
        }

        /// <summary>
        /// Get sorted list of project by name
        /// </summary>
        /// <returns>Returns sorted list by name</returns>
        [HttpGet("sortByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SortByName()
        {
            var pjs = _projectService.GetAllProjects();
            var result = _sortService.SortByName(pjs);
            return Ok(result);
        }


        /// <summary>
        /// Get sorted list of project by priority
        /// </summary>
        /// <returns>Returns sorted list by priority</returns>
        [HttpGet("SortByPriority")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SortByPriority()
        {
            var result = _sortService.SortByPriority(_projectService.GetAllProjects());
            return Ok(result);
        }

        /// <summary>
        /// Get sorted list of project by start date
        /// </summary>
        /// <returns>Returns sorted list by start date</returns>
        [HttpGet("SortByStartDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SortByStartDate(IEnumerable<Project> spurceProjects)
        {
            var result = _sortService.SortByStartDate(_projectService.GetAllProjects());
            return Ok(result);
        }

        /// <summary>
        /// Get sorted list of project by status
        /// </summary>
        /// <returns>Returns sorted list by status</returns>
        [HttpGet("SortByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SortByStatus(IEnumerable<Project> spurceProjects)
        {
            var result = _sortService.SortByStatus(_projectService.GetAllProjects());
            return Ok(result);
        }
        #endregion
    }
}
