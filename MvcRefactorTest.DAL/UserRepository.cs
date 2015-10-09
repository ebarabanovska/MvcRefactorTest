using log4net;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Domain.db;
using MvcRefactorTest.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.DAL
{
    public class UserRepository : MvcRefactorTest.DAL.IUserRepository
    {
        private dbContext _context;
        private readonly ILog logger = LogFactory.GetLogger();

        #region Get methods

        /// <summary>
        /// Get user By Id
        /// </summary>
        /// <param name="id">user Id</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetUserBy(int id, out User userObj)
        {
            bool succeed = false;
            userObj = null;

            try
            {
                using (_context = new dbContext())
                {
                    userObj = _context.User.Where(p => p.id == id).SingleOrDefault();
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        /// Validate user by username and password
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Return true if success, else false</returns>
        public bool ValidateUser(string userName, string password, out bool isValid)
        {
            bool succeed = false;
            isValid = false;

            try
            {
                using (_context = new dbContext())
                {
                    isValid = _context.User.Where(p => p.name == userName && p.password == password).SingleOrDefault() != null ? true : false;
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        /// Get user By Name
        /// </summary>
        /// <param name="name">user Name</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetUserBy(string name, out User userObj)
        {
            bool succeed = false;
            userObj = null;

            try
            {
                using (_context = new dbContext())
                {
                    userObj = _context.User.Where(p => p.name == name).SingleOrDefault();
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetAllUsers(out IList<User> userList)
        {
            bool succeed = false;
            userList = null;

            try
            {
                using (_context = new dbContext())
                {
                    userList = _context.User.ToList<User>();
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        /// Get All users by active flag
        /// </summary>
        /// <param name="active">is Enabled</param>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetAllUsersBy(bool active, out IList<User> userList)
        {
            bool succeed = false;
            userList = null;

            try
            {
                using (_context = new dbContext())
                {
                    userList = _context.User.Where(p => p.isEnabled == active).ToList();
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        #endregion

        #region Create/Update/Delete

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="fullName">User full name</param>
        /// <param name="password">Password</param>
        /// <param name="role">Role</param>
        /// <param name="userObj">User object to be retrieved</param>
        /// <returns>Return true if success, else false</returns>
        public bool CreateUser(string fullName, string password, string role, out User userObj)
        {
            bool succeed = false;
            userObj = null;

            try
            {
                using (_context = new dbContext())
                {
                    userObj = new User
                    {
                        name = fullName,
                        password = password,
                        role = role,
                        isEnabled = true
                    };
                    _context.User.Add(userObj);
                    _context.SaveChanges();

                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        /// Change Users Password
        /// </summary>
        /// <param name="fullName">fullName</param>
        /// <param name="password">Password</param>
        /// <param name="userObj">User Ooject to be retrieved</param>
        /// <returns>Return true if success, else false</returns>
        public bool ChangePassword(string fullName, string password)
        {
            bool succeed = false;
            User userObj = null;

            try
            {
                using (_context = new dbContext())
                {
                    userObj = _context.User.Where(p => p.name == fullName).SingleOrDefault();
                    userObj.password = password;

                    _context.SaveChanges();

                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        /// Remove user from Role
        /// </summary>
        /// <param name="fullName">fullName</param>
        /// <param name="password">Password</param>
        /// <returns>Return true if success, else false</returns>
        public bool RemoveUserFromRole(string fullName, string role, out User userObj)
        {
            bool succeed = false;
            userObj = new User();

            try
            {
                using (_context = new dbContext())
                {
                    userObj = _context.User.Where(p => p.name == fullName).SingleOrDefault();
                    userObj.role = string.Empty;

                    _context.SaveChanges();

                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }



        #endregion
    }
}
