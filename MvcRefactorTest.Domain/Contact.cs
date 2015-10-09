using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.Domain
{
    public class Contact : BaseClass
    {
        [Required]
        [Display(Name = "Main Phone")]
        public string mainPhone { get; set; }

        [Required]
        [Display(Name = "After Hours Phone")]
        public string afterHours { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Support")]
        public string supportEmail { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Marketing")]
        public string marketingEmail { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "General")]
        public string generalEmail { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
    }
}
