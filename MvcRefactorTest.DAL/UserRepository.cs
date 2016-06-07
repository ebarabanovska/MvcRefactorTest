using System;
using System.Collections.Generic;
using System.Linq;

using log4net;

using MvcRefactorTest.Common;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Domain.db;

namespace MvcRefactorTest.DAL
{
    [LoggingAspect]
    public class UserRepository : IUserRepository
    {
        private dbContext _context;

        /// <summary>
        ///     Change Password.
        /// </summary>
        /// <param name="fullName">User full name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Return true if success, else false.</returns>
        public bool ChangePassword(string fullName, string password)
        {
            var succeed = false;

            using (this._context = new dbContext())
            {
                var userObj = this._context.User.SingleOrDefault(p => p.Name == fullName);
                if (userObj != null) userObj.Password = password;

                this._context.SaveChanges();

                succeed = true;
            }

            return succeed;
        }

        /// <summary>
        ///     Create new User.
        /// </summary>
        /// <param name="fullName">User full name.</param>
        /// <param name="password">User Password.</param>
        /// <param name="role">User Role.</param>
        /// <param name="userObj">User object to be retrieved.</param>
        /// <returns>Return true if success, else false.</returns>
        //public bool CreateUser(string fullName, string password, string role, out User userObj)
        //{
        //    var succeed = false;

        //    using (this._context = new dbContext())
        //    {
        //        userObj = new User { Name = fullName, Password = password, Role = role, IsEnabled = true };
        //        this._context.User.Add(userObj);
        //        this._context.SaveChanges();

        //        succeed = true;
        //    }

        //    return succeed;
        //}

        /// <summary>
        ///     Get All users
        /// </summary>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        public bool GetAllUsers(out IList<User> userList)
        {
            var succeed = false;

            using (this._context = new dbContext())
            {
                userList = this._context.User.ToList();
                succeed = true;
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

            using (this._context = new dbContext())
            {
                userList = this._context.User.Where(p => p.IsEnabled == active).ToList();
                succeed = true;
            }

            return succeed;
        }

        /// <summary>
        ///     Get user By Id.
        /// </summary>
        /// <param name="id">user Id.</param>
        /// <param name="userObj">Object to be retrieved.</param>
        /// <returns>Returns true if success, else false.</returns>
        public bool GetUserBy(int id, out User userObj)
        {
            var succeed = false;

            using (this._context = new dbContext())
            {
                userObj = this._context.User.SingleOrDefault(p => p.id == id);
                succeed = true;
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

            using (this._context = new dbContext())
            {
                userObj = this._context.User.SingleOrDefault(p => p.Name == name);
                succeed = true;
            }

            return succeed;
        }

        /// <summary>
        ///     Remove user from Role.
        /// </summary>
        /// <param name="fullName">User full name.</param>
        /// <param name="role">User Role.</param>
        /// <param name="userObj">User object to be retrieved.</param>
        /// <returns>Return true if success, else false.</returns>
        //public bool RemoveUserFromRole(string fullName, string role, out User userObj)
        //{
        //    var succeed = false;

        //    using (this._context = new dbContext())
        //    {
        //        userObj = this._context.User.SingleOrDefault(p => p.Name == fullName);
        //        if (userObj != null && userObj.Role == role) userObj.Role = string.Empty;

        //        this._context.SaveChanges();

        //        succeed = true;
        //    }

        //    return succeed;
        //}

        /// <summary>
        ///     Validate User.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">User password.</param>
        /// <param name="isValid">Is user valid.</param>
        /// <returns>Returns true if success, else false.</returns>
        public bool ValidateUser(string userName, string password, out bool isValid)
        {
            var succeed = false;

            using (this._context = new dbContext())
            {
                isValid = this._context.User.SingleOrDefault(p => p.Name == userName && p.Password == password) != null
                              ? true
                              : false;
                succeed = true;
            }

            return succeed;
        }
    }
}