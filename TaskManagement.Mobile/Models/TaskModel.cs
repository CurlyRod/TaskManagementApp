﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Mobile.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } 
        public string CreatedDate { get; set; }  
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
        public string TaskStatus { get; set; } 
        public bool ActiveInactice { get; set; } 
    }
}
