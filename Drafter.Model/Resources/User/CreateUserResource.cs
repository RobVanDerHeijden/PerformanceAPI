using System;
using System.ComponentModel.DataAnnotations;

namespace Drafter.Model.Resources
{
    public class CreateUserResource
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [StringLength(72)]
        public string Password { get; set; }
    }
}
