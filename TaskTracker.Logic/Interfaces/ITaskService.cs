using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Model;

namespace TaskTracker.Logic.Interfaces
{
    public interface ITaskService
    {
        public void CreateTask(int projectId, string taskName,
            string taskDescritption, DateTime startDate, DateTime finishDate,
            MyTaskStatus status, int priority);

        public void DeleteTask(int id);

        public void UpdateTask(int id, int projectId, string taskName,
            string taskDescritption, DateTime startDate, DateTime finishDate,
            MyTaskStatus status, int priority);

        public MyTask GetTaskById(int id);

        public IEnumerable<MyTask> GetTasksByProject(int projectId);
    }
}
