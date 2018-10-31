using System;
using System.Collections.Generic;
using System.ComponentModel;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace DocsExchange.ViewModels
{
    public class ContractsView
    {
        public int Id { get; set; }
        [DisplayName("№ договору")]
        public string DocNumber { get; set; }
        [DisplayName("Видалити")]
        public bool IsDeleted { get; set; }
        [DisplayName("Дата початку")]
        public DateTime DateStart { get; set; }
        [DisplayName("Дата закінчення")]
        public DateTime DateEnd { get; set; }
        [DisplayName("Партнер")]
        public string PartnerName { get; set; }
        public int Partner { get; set; }
        [DisplayName("Відповідальний")]
        public string ResponsibleName { get; set; }
        public int Responsible { get; set; }
        [DisplayName("Відділ")]
        public string DepartamentName { get; set; }
        public int Departament { get; set; }
        [DisplayName("Назва файлу")]
        public string FileName { get; set; }
        [DisplayName("Файл")]
        public IFormFile Files { get; set; }
        [DisplayName("Фірма")]
        public string CompanyName { get; set; }
        public int Company { get; set; }
    }
}