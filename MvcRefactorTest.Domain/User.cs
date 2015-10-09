using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.Domain
{
    public class User : BaseClass
    {
        [Required]
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string role { get; set; }

        [Required]
        [Display(Name = "is Enabled")]
        public bool isEnabled { get; set; }

    }
}
