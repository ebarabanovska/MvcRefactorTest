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

            return _userService.GetAllUsers(out userObj)
                ? PartialView("_UserDetailsPartial", (List<User>) userObj)
                : PartialView(null);
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
            return _contactService.GetContactDetails(out contactObj) ? View(contactObj) : View();
        }
    }
}