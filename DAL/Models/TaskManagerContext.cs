using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
   public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
