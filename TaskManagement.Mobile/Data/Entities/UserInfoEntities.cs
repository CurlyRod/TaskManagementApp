
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace TaskManagement.Mobile.Models
{
    [Table("Userinfo")]
    public class UserInfoEntities
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; } 
        public string CreatedDate { get; set; }
    }
}
