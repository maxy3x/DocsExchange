using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Employee : DeletableEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String SecondName { get; set; }
        public int OkpoCode { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public int Departament { get; set; }
        public string User { get; set; }
    }
}