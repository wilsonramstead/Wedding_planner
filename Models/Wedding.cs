using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace wedding_planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID {get;set;}

        [Required]
        [MinLength(2)]
        public string Name1 {get;set;}

        [Required]
        [MinLength(2)]
        public string Name2 {get;set;}

        [Required]
        public DateTime Date {get;set;}

        [Required]
        public string Address {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Event> Weddings {get;set;}
        public User creator {get;set;}
        public int CreatorID {get;set;}


    }
}