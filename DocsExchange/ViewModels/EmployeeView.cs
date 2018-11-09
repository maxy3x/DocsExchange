using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace DocsExchange.ViewModels
{
    public class EmployeeView
    {
        public int Id { get; set; }
        [DisplayName("Видалити")]
        public bool IsDeleted { get; set; }
        [DisplayName("Повідомлення")]
        public String Message { get; set; }
        [Required]
        [DisplayName("Повне ім'я")]
        public String Name { get; set; }
        [Required]
        [DisplayName("Ім'я")]
        public String FirstName { get; set; }
        [Required]
        [DisplayName("Прізвище")]
        public String SecondName { get; set; }
        [DisplayName("По-батькові")]
        public string Patronymic { get; set; }
        [DisplayName("ОКПО")]
        public long Okpo { get; set; }
        [Required]
        [DisplayName("Відділ")]
        public string DepartamentName { get; set; }
        public int Departament { get; set; }
        [DisplayName("Користувач")]
        public string UserName { get; set; }
        public string User { get; set; }
    }
}