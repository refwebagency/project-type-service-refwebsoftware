using System.ComponentModel.DataAnnotations;

namespace ProjectTypeService.Models
{
    public class ProjectType
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}