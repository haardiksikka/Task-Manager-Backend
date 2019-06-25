using System;
using System.ComponentModel.DataAnnotations;


namespace DAL.Models
{
    public class Task
    {
       
        [Key]
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
        public int UserId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public User User { get; set; }
    }
}
