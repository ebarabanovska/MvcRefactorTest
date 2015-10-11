using System;
using System.Collections.Generic;
using log4net;
using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.DAL;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Log4Net;

namespace MvcRefactorTest.BL
{
    public class UserService : IUserService
    {
        #region Constructor

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Private Members

        private readonly IUserRepository _userRepository;
        private readonly ILog _logger = LogFactory.GetLogger();

        #endregion

        #region Get methods

        /// <summary>
        ///     Get user By Id
        /// </summary>
        /// <param name="id">user Id</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetUserBy(int id, out User userObj)
        {
            var succeed = false;
            userObj = null;

            try
            {
                if (_userRepository.GetUserBy(id, out userObj))
                    succeed = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        ///     Validate user by username and password
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Return true if success, else false</returns>
        public bool ValidateUser(string userName, string password, out bool isValid)
        {
            var succeed = false;
            isValid = false;

            try
            {
                if (_userRepository.ValidateUser(userName, password, out isValid))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        ///     Get user By Name
        /// </summary>
        /// <param name="name">user Name</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetUserBy(string name, out User userObj)
        {
            var succeed = false;
            userObj = null;

            try
            {
                if (_userRepository.GetUserBy(name, out userObj))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        ///     Get All users
        /// </summary>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetAllUsers(out IList<User> userList)
        {
            var succeed = false;
            userList = null;

            try
            {
                if (_userRepository.GetAllUsers(out userList))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        ///     Get All users by active flag
        /// </summary>
        /// <param name="active">is Enabled</param>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetAllUsersBy(bool active, out IList<User> userList)
        {
            var succeed = false;
            userList = null;

            try
            {
                if (_userRepository.GetAllUsersBy(active, out userList))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        #endregion

        #region Create/Update/Delete

        /// <summary>
        ///     Create new User
        /// </summary>
        /// <param name="fullName">User full name</param>
        /// <param name="password">Password</param>
        /// <param name="role">Role</param>
        /// <param name="userObj">User object to be retrieved</param>
        /// <returns>Return true if success, else false</returns>
        public bool CreateUser(string fullName, string password, string role, out User userObj)
        {
            var succeed = false;
            userObj = null;

            try
            {
                if (_userRepository.CreateUser(fullName, password, role, out userObj))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        /// <summary>
        ///     Change Users Password
        /// </summary>
        /// <param name="fullName">fullName</param>
        /// <param name="password">Password</param>
        /// <param name="userObj">User Ooject to be retrieved</param>
        /// <returns>Return true if success, else false</returns>
        public bool ChangePassword(string fullName, string password)
        {
            var succeed = false;

            try
            {
                if (_userRepository.ChangePassword(fullName, password))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        public bool RemoveUserFromRole(string fullName, string role, out User userObj)
        {
            var succeed = false;
            userObj = new User();

            try
            {
                if (_userRepository.RemoveUserFromRole(fullName, role, out userObj))
                {
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        #endregion
    }
}