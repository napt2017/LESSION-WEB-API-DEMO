using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LESSION_WEB_API_DEMO.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        public string PassWord { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public int RoleId { get; set; }
    }
}