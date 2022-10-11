using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Model
{
    public enum MyTaskStatus { ToDo, InProgress, Done }
    public class MyTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime FinishDate { get; set; }
        public MyTaskStatus Status { get; set; } = MyTaskStatus.ToDo;
        public int Priority { get; set; } = 1;
    }
}
