using System.ComponentModel.DataAnnotations;

namespace ProjectTypeService.Dtos
{
    public class ProjectTypeCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}