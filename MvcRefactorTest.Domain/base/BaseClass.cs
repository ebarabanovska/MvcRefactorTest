using System;
using System.ComponentModel.DataAnnotations;

namespace MvcRefactorTest.Domain.@base
{
    public class BaseClass
    {
        public BaseClass()
        {
            this.DateCreated = DateTime.Now;
            this.DateUpdated = DateTime.Now;
            this.IsDeleted = false;
        }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created ")]
        public DateTime DateCreated { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Updated ")]
        public DateTime DateUpdated { get; set; }

        [Key]
        [Required]
        public int id { get; set; }

        [Display(Name = "Is Deleted")]
        [Required(ErrorMessage = "Please set the Deleted flag")]
        public bool IsDeleted { get; set; }
    }
}