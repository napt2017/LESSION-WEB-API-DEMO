using System.ComponentModel.DataAnnotations;

namespace LESSION_WEB_API_DEMO.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}