using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace DocsExchange.Models.Filters
{
    public class FilterEployees
    {
        public string Name { get; set; }
        public int OkpoCode { get; set; }
        public string Departament { get; set; }
    }
}