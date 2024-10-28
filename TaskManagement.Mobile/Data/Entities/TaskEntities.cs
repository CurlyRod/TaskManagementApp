using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Mobile.Data.Entities
{
    [Table("TaskDetails")]
    public class TaskEntities
    {
        [Key]   
        public int Id { get; set; }
        public int UserId { get; set; }  
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = DateTime.Now.ToString("M/dd/yyyy");
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string TaskStatus { get; set; } = "New";
        public bool ActiveInactice { get; set; } = true;
    }
}
