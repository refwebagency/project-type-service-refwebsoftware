using System.ComponentModel.DataAnnotations;

namespace ProjectTypeService.Dtos
{
    public class ProjectTypeUpdateAsyncDto
    {
         [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Event { get; set; }
    }
}