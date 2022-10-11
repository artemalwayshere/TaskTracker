using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Model
{
    public enum ProjectStatus { NotStarted, Active, Completed }
    public  class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime FinishDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.NotStarted;
        public int Priority { get; set; }
        public List<MyTask> Tasks { get; set; }
    }
}
