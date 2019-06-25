using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Task
    {
        public string Email { get; set; }
        public int TaskId { get; set; }
        [Required]
        public string UserStory { get; set; }
        [Required]
        public int TimeLogged { get; set; }
        [Required]
        public int AllocatedTime { get; set; }
        [Required]
        public string TaskDomain { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}
