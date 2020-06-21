using System.ComponentModel.DataAnnotations;

namespace Drafter.Model.Resources
{
    public class AuthenticationResource
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}