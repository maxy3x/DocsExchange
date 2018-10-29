using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class IdEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}