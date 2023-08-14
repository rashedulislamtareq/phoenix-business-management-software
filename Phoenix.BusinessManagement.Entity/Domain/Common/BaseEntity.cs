using System.ComponentModel.DataAnnotations;

namespace Phoenix.BusinessManagement.Entity.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public byte StatusId { get; set; }
    }
}
