using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.Domain
{
    public static class Extensions
    {
        //public static IQueryable<Contact> AllChildrenContact(this db.dbContext context)
        //{
        //    return context.Contact.Include("Contact");
        //}
    }

    public class BaseClass
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created ")]
        public DateTime date_created { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Updated ")]
        public DateTime date_updated { get; set; }

        [Display(Name = "Is Deleted")]
        [Required(ErrorMessage = "Please set the Deleted flag")]
        public bool isDeleted { get; set; }

        public BaseClass()
        {
            date_created = DateTime.Now;
            date_updated = DateTime.Now;
            isDeleted = false;
        }
    }
}

