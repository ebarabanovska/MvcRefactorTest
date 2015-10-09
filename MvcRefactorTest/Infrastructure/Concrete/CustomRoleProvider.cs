using MvcRefactorTest.BL;
using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.DAL;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcRefactorTest.Infrastructure.Concrete
{
    public class CustomRoleProvider : RoleProvider
    {

        #region Private Members

        private string pApplicationName;

        private IUserService _userService;

        private IUserRepository _userRepository;

        #endregion

        #region Initialise Constructor

        /// <summary>
        /// Initialize Constructor
        /// </summary>
        public CustomRoleProvider()
        {
            _userRepository = new UserRepository(); ;
            this._userService = new UserService(_userRepository);
        }

        /// <summary>
        /// Application Name
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                return pApplicationName;
            }
            set
            {
                pApplicationName = value;
            }
        }

        #endregion Initialise Constructor


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find User in Role
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="usernameToMatch"></param>
        /// <returns>Find all of Users in the role</returns>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            IList<User> userList;
            List<string> users = new List<string>();

            try
            {
                if (_userService.GetAllUsers(out userList))
                    if (userList != null)
                        return userList == null ? new string[] { } : userList.Where(p => p.role == roleName).Select(p => p.name).ToArray();
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error(ex.Message, ex.InnerException);
            }
            return new string[] { };
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            User userObj = new User();

            try
            {
                if (_userService.GetUserBy(username, out userObj))
                    if (userObj != null)
                        return userObj.role != null ? new string[] { userObj.role } : new string[] { };
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error(ex.Message, ex.InnerException);
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is User In Role
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns>Returns true if exists, else false</returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            User userObj = new User();

            try
            {
                if (_userService.GetUserBy(username, out userObj))
                    if (userObj != null)
                        return (userObj.role != null && userObj.role == roleName);
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error(ex.Message, ex.InnerException);
            }
            return false;
        }

        /// <summary>
        /// Remove Users from Roles
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="rolenames"></param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            User userObj = new User();

            try
            {
                foreach (string user in usernames)
                {
                    if (_userService.GetUserBy(user, out userObj))
                        foreach (string role in roleNames)
                        {
                            if (userObj != null)
                            {
                                userObj.role = string.Empty;
                                _userService.RemoveUserFromRole(user, role, out userObj);
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error(ex.Message, ex.InnerException);
            }

        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}