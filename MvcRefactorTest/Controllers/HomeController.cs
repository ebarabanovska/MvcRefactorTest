using Microsoft.AspNet.Identity.EntityFramework;
using MvcRefactorTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MvcRefactorTest.Domain;
using System.Web.Security;
using MvcRefactorTest.Log4Net;
using log4net;
using MvcRefactorTest.BL.Interface;


namespace MvcRefactorTest.Controllers
{

    [Authorize(Roles = "Developer")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IContactService _contactService;
        private static readonly ILog logger = LogFactory.GetLogger();

        #region Controller Constructors

        public HomeController(IUserService userService, IContactService contactRepository)
        {
            _userService = userService;
            _contactService = contactRepository;
        }

        #endregion

        public ActionResult Index()
        {
            ViewBag.Title = "All Developers";

            //FormsAuthentication.SetAuthCookie(System.Security.Principal.WindowsIdentity.GetCurrent().Name, false);
            //logger.Error("Test Error");
            return View();
        }

        public ActionResult LoadUsers()
        {
            IList<User> userObj;

            if (_userService.GetAllUsers(out userObj))
                return PartialView("_UserDetailsPartial", userObj);
            else
                return PartialView(null);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            Contact contactObj;
            if (_contactService.GetContactDetails(out contactObj))
                return View(contactObj);
            else return View();
        }
    }
}
