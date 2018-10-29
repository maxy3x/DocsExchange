using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Company : DeletableEntity
    {
        [Required]
        public String Name { get; set; }
    }
}