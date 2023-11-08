using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
