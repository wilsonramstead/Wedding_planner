using System;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
    public class UserLogin
    {
        [EmailAddress]
        public string logEmail {get;set;}
        public string Password {get;set;}
    }
}