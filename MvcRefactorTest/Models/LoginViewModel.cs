using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcRefactorTest.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter valid username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}