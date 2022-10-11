using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Model;

namespace TaskTracker.Logic.Interfaces
{
    internal interface IProjectService
    {
        public void CreateProject(string projectName, 
            string projectDescription, 
            DateTime startDate, 
            DateTime finishdate,
            ProjectStatus projectStatus,
            int priority);

        public void UpdateProject(string projectName,
            string projectDescription,
            DateTime startDate,
            DateTime finishdate,
            ProjectStatus projectStatus,
            int priority, int id);

        public void DeleteProject(int id);

        public IEnumerable<Project> GetAllProjects();

        public Project GetProjectById(int id);

    }
}
