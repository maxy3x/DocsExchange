using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Contracts : DeletableEntity
    {
        public string DocNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        [Required]
        public int Partner { get; set; }
        [Required]
        public int Responsible { get; set; }
        [Required]
        public int Departament { get; set; }
        public IEnumerable<Attachments>  Attachments { get; set; }
        public byte[] Files { get; set; }
        public int Company { get; set; }
    }
}