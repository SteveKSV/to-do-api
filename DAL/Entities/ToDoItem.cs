using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public bool Status { get; set; } = false;
    }
}
