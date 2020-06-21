using System.ComponentModel.DataAnnotations;

namespace Drafter.Model.Resources
{
    public class UpdateUserResource
    {
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(320)]
        public string Email { get; set; }
    }
}