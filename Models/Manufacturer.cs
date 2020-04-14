using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LESSION_WEB_API_DEMO.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Address { get; set; }

        public Collection<Product> Products { get; set; } = new Collection<Product>();
    }
}