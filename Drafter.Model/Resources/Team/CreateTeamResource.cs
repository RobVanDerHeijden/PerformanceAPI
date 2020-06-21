using System;
using System.ComponentModel.DataAnnotations;

namespace Drafter.Model.Resources
{
    public class CreateTeamResource
    {
        [StringLength(50, ErrorMessage = "Name to long")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(5, ErrorMessage = "Tag to long")]
        [Required(ErrorMessage = "Tag is required")]
        public string Tag { get; set; }

    }
}
