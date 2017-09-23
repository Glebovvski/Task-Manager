using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskManager.Models
{
    public class PersonalTask
    {
        public PersonalTask()
        {
            Tags = new List<string>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public List<string> Tags { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(20), MaxLength(100000)]
        public string Content { get; set; }
        public DateTime LastModified { get; set; }
    }
}
