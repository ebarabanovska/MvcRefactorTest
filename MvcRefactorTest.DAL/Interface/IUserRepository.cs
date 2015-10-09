using MvcRefactorTest.Domain;
using System;
namespace MvcRefactorTest.DAL
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user By Id
        /// </summary>
        /// <param name="id">user Id</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        bool GetAllUsers(out System.Collections.Generic.IList<MvcRefactorTest.Domain.User> userList);

        /// <summary>
        /// Get All users
        /// </summary>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        bool GetAllUsersBy(bool active, out System.Collections.Generic.IList<MvcRefactorTest.Domain.User> userList);

        /// <summary>
        /// Get user By Name
        /// </summary>
        /// <param name="name">user Name</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        bool GetUserBy(string name, out User userObj);

        /// <summary>
        /// Validate user by username and password
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Return true if success, else false</returns>
        bool ValidateUser(string userName, string password, out bool isValid);

        /// <summary>
        /// Get All users by active flag
        /// </summary>
        /// <param name="active">is Enabled</param>
        /// <param name="userList">user List</param>
        /// <returns>Returns true if success, else false</returns>
        bool GetUserBy(int id, out MvcRefactorTest.Domain.User userObj);

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="fullName">User full name</param>
        /// <param name="password">Password</param>
        /// <param name="role">Role</param>
        /// <param name="userObj">User object to be retrieved</param>
        /// <returns>Return true if success, else false</returns>
        bool CreateUser(string fullName, string password, string role, out User userObj);

        /// <summary>
        /// Change Users Password
        /// </summary>
        /// <param name="fullName">fullName</param>
        /// <param name="password">Password</param>
        /// <param name="userObj">User Ooject to be retrieved</param>
        /// <returns>Return true if success, else false</returns>
        bool ChangePassword(string fullName, string password);

        /// <summary>
        /// Remove user from Role
        /// </summary>
        /// <param name="fullName">fullName</param>
        /// <param name="password">Password</param>
        /// <returns>Return true if success, else false</returns>
        bool RemoveUserFromRole(string fullName,string role,out User userObj);
    }
}
