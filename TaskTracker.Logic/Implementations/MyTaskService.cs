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
    public class MyTaskService : ITaskService
    {
        private readonly TrackerDBContext _context;

        public MyTaskService(TrackerDBContext context)
        {
            _context = context;
        }

        public void CreateTask(int id, int projectId, string taskName, string taskDescritption, 
            DateTime startDate, DateTime finishDate, MyTaskStatus status, int priority)
        {
            var project = _context.Projects.FirstOrDefault(i => i.Id == projectId);

            var task = new MyTask
            {
                Id = id,
                ProjectId = projectId,
                TaskName = taskName,
                FinishDate = finishDate,
                Status = status,
                Priority = priority,
                StartDate = startDate,
                TaskDescription = taskDescritption,
            };

            project.Tasks.Add(task);

            _context.Tasks.AddAsync(task);

            _context.SaveChangesAsync();
        }

        public void DeleteTask(int id)
        {
            var response = GetTaskById(id);
            _context.Tasks.Remove(response);

            _context.SaveChangesAsync();
        }

        public MyTask GetTaskById(int id)
        {
            var myTask = _context.Tasks.FirstOrDefault(i => i.Id == id);

            return myTask;
        }


        public IEnumerable<MyTask> GetTasksByProject(int projectId)
        {
            var tasks = _context.Tasks.Where(i => i.ProjectId == projectId)
                .ToList();

            return tasks;
        }

        public void UpdateTask(int id, int projectId, string taskName, string taskDescritption, 
            DateTime startDate, DateTime finishDate, MyTaskStatus status, int priority)
        {
            var task = GetTaskById(id);

            task.TaskName = taskName;
            task.ProjectId = projectId;
            task.TaskDescription = taskDescritption;
            task.Status = status;
            task.StartDate = startDate;
            task.FinishDate = finishDate;
            task.Priority = priority;

            _context.SaveChangesAsync();
        }
    }
}
