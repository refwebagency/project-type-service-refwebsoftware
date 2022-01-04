using System.ComponentModel.DataAnnotations;

namespace ProjectTypeService.Dtos
{
    public class ProjectTypeUpdateDto
    {
         [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}