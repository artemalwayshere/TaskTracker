using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Model;

namespace TaskTracker.Logic.Interfaces
{
    public interface ISortService
    {
        public IEnumerable<Project> SortByName(IEnumerable<Project> projects);
        public IEnumerable<Project> SortByStartDate(IEnumerable<Project> project);
        public IEnumerable<Project> SortByFinishDate(IEnumerable<Project> project);
        public IEnumerable<Project> SortByStatus(IEnumerable<Project> projects);
        public IEnumerable<Project> SortByPriority(IEnumerable<Project> projects);
    }
}
