using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Model;

namespace TaskTracker.DAL
{
    public class TrackerDBContext : DbContext
    {
        public TrackerDBContext(DbContextOptions<TrackerDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<MyTask> Tasks { get; set; }


    }
}
