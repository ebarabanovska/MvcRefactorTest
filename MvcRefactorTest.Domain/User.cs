using System.ComponentModel.DataAnnotations;

using MvcRefactorTest.Domain.@base;

namespace MvcRefactorTest.Domain
{
    public class User : BaseClass
    {
        [Required]
        [Display(Name = "is Enabled")]
        public bool IsEnabled { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}