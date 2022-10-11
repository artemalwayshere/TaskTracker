using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL;
using TaskTracker.DAL.Model;
using TaskTracker.Logic.Interfaces;

namespace TaskTracker.Logic.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly TrackerDBContext _context;

        public ProjectService(TrackerDBContext context)
        {
            _context = context;
        }

        public void CreateProject(string projectName, string projectDescription, 
            DateTime startDate, DateTime finishdate, ProjectStatus projectStatus, int priority)
        {
            var project = new Project
            {
                ProjectName = projectName,
                ProjectDescription = projectDescription,
                StartDate = startDate,
                FinishDate = finishdate,
                ProjectStatus = projectStatus,
                Priority = priority
            };

            _context.Projects.AddAsync(project);

            _context.SaveChangesAsync();
        }

        public void DeleteProject(int id)
        {
            var project = GetProjectById(id);

            _context.Remove(project);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _context.Projects.Include(p => p.Tasks);
            return projects;
        }

        public Project GetProjectById(int id)
        {
            var projects = _context.Projects.Include(p => p.Tasks).FirstOrDefault();

            if (projects == null)
            {
                throw new Exception();  //TODO: NotFoundException
            }
            return projects;
        }

        public void UpdateProject(string projectName, string projectDescription, 
            DateTime startDate, DateTime finishdate, ProjectStatus projectStatus, int priority, int id)
        {
            var project = GetProjectById(id);

            project.ProjectName = projectName;
            project.ProjectDescription = projectDescription;
            project.StartDate = startDate;
            project.FinishDate = finishdate;
            project.Priority = priority;

            _context.SaveChangesAsync();
        }
    }
}
