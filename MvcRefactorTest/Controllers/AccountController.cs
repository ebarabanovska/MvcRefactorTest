using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Infrastructure.Abstract;
using MvcRefactorTest.Log4Net;

namespace MvcRefactorTest.Controllers
{
    public class AccountController : Controller
    {
        #region Constructors

        public AccountController(IUserService userService, ICustomMembershipProvider authProvider)
        {
            _authProvider = authProvider;
            _userService = userService;
        }

        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Validate(string username, string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_authProvider.Authenticate(username, password)) if (SetupFormsAuthTicket(username, password, false)) return Redirect(Url.Action("Index", "Home"));
                }
                catch (Exception ex)
                {
                    LogFactory.GetLogger().Error(ex.Message, ex.InnerException);
                }
            }

            return View("Login");
        }

        #region Private Properties

        private readonly ICustomMembershipProvider _authProvider;

        private readonly IUserService _userService;

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="persistanceFlag"></param>
        /// <returns></returns>
        private bool SetupFormsAuthTicket(string username, string password, bool persistanceFlag)
        {
            var success = false;

            try
            {
                User userObj;
                _userService.GetUserBy(username, out userObj);

                var userId = userObj.id;
                var userData = userId.ToString(CultureInfo.InvariantCulture);
                var authTicket = new FormsAuthenticationTicket(
                    1, 

                    // version
                    username, 

                    // user name                    
                    DateTime.Now, 

                    // creation
                    DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"])), 

                    // Expiration
                    persistanceFlag, 

                    // Persistent
                    userData);

                var encTicket = FormsAuthentication.Encrypt(authTicket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                success = true;
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error(ex.Message, ex.InnerException);
            }

            return success;
        }

        #endregion Private Properties
    }
}