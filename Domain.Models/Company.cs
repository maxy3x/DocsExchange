using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Company : DeletableEntity
    {
        [Required]
        [DisplayName("Назва компанії")]
        public String Name { get; set; }
    }
}