using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_Backend.Data
{
    public class Employee 
    {
        [Key] 
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        //public string TaxId { get; set; }
        public string Role { get; set; }

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }

        // Navigation property
        public Team Team { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
