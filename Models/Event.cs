using System;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class Event
    {
        [Key]
        public int EventID {get;set;}

        [Required]
        public int UserID {get;set;}

        [Required]
        public int WeddingID {get;set;}

        public User User {get;set;}

        public Wedding Wedding {get;set;}
    }
}