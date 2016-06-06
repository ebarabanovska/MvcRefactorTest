using System.ComponentModel.DataAnnotations;

using MvcRefactorTest.Domain.@base;

namespace MvcRefactorTest.Domain
{
    public class Contact : BaseClass
    {
        [Required]
        [Display(Name = "Main Phone")]
        public string MainPhone { get; set; }

        [Required]
        [Display(Name = "After Hours Phone")]
        public string AfterHours { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Support")]
        public string SupportEmail { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Marketing")]
        public string MarketingEmail { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "General")]
        public string GeneralEmail { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}