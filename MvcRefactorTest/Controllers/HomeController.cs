using System.Collections.Generic;
using System.Web.Mvc;

using log4net;

using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Log4Net;

namespace MvcRefactorTest.Controllers
{
    [Authorize(Roles = "Developer")]
    public class HomeController : Controller
    {
        private static readonly ILog Logger = LogFactory.GetLogger();

        private readonly IContactService _contactService;

        private readonly IUserService _userService;

        public HomeController(IUserService userService, IContactService contactRepository)
        {
            this._userService = userService;
            this._contactService = contactRepository;
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your app description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            Contact contactObj;
            return this._contactService.GetContactDetails(out contactObj) ? this.View(contactObj) : this.View();
        }

        public ActionResult Index()
        {
            this.ViewBag.Title = "All Developers";

            // FormsAuthentication.SetAuthCookie(System.Security.Principal.WindowsIdentity.GetCurrent().Name, false);
            // logger.Error("Test Error");
            return this.View();
        }

        public ActionResult LoadUsers()
        {
            IList<User> userObj;

            return this._userService.GetAllUsers(out userObj)
                       ? this.PartialView("_UserDetailsPartial", (List<User>)userObj)
                       : this.PartialView(null);
        }
    }
}