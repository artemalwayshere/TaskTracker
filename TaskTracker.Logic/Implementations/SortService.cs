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
    public class SortService : ISortService
    {
        public IEnumerable<Project> SortByFinishDate(IEnumerable<Project> projects)
        {
            var sortedList = projects.OrderBy(p => p.FinishDate).ToList();
            return sortedList;
        }

        public IEnumerable<Project> SortByName(IEnumerable<Project> projects)
        {
            var sortedList = projects.OrderBy(p => p.ProjectName).ToList();
            return sortedList;
        }

        public IEnumerable<Project> SortByPriority(IEnumerable<Project> projects)
        {
            var sortedList = projects.OrderBy(p => p.Priority).ToList();
            return sortedList;
        }

        public IEnumerable<Project> SortByStartDate(IEnumerable<Project> projects)
        {
            var sortedList = projects.OrderByDescending(p => p.StartDate).ToList();
            return sortedList;
        }

        public IEnumerable<Project> SortByStatus(IEnumerable<Project> projects)
        {
            var sortedList = projects.OrderBy(p => p.ProjectStatus).ToList();
            return sortedList;
        }
    }
}
