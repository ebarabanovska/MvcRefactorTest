using System.Collections.Generic;

using MvcRefactorTest.Domain;

namespace MvcRefactorTest.DAL.Interface
{
    public interface IUserRepository
    {
        /// <summary>
        ///     Change User Password.
        /// </summary>
        /// <param name="fullName">User full name.</param>
        /// <param name="password">User Password.</param>
        /// <returns>Return true if success, else false.</returns>
        bool ChangePassword(string fullName, string password);

        /// <summary>
        ///     Create new User.
        /// </summary>
        /// <param name="fullName">User full name.</param>
        /// <param name="password">Password.</param>
        /// <param name="role">User Role.</param>
        /// <param name="userObj">User object to be retrieved.</param>
        /// <returns>Return true if success, else false.</returns>
        bool CreateUser(string fullName, string password, string role, out User userObj);

        /// <summary>
        ///     Get All Users.
        /// </summary>
        /// <param name="userList">User List.</param>
        /// <returns>Returns true if success, else false.</returns>
        bool GetAllUsers(out IList<User> userList);

        /// <summary>
        ///     Get All active Users.
        /// </summary>
        /// <param name="active">Is Active.</param>
        /// <param name="userList">User List.</param>
        /// <returns>Returns true if success, else false.</returns>
        bool GetAllUsersBy(bool active, out IList<User> userList);

        /// <summary>
        ///     Get user By Name
        /// </summary>
        /// <param name="name">user Name</param>
        /// <param name="userObj">Object to be retrieved</param>
        /// <returns>Returns true if success, else false</returns>
        bool GetUserBy(string name, out User userObj);

        /// <summary>
        ///     Get User by Id.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <param name="userObj">User Object to be returned.</param>
        /// <returns>Return true if success, else false.</returns>
        bool GetUserBy(int id, out User userObj);

        /// <summary>
        ///     Remove User from Role.
        /// </summary>
        /// <param name="fullName">User full name.</param>
        /// <param name="role">User Role.</param>
        /// <param name="userObj">User Object to be returned.</param>
        /// <returns>Return true if success, else false.</returns>
        bool RemoveUserFromRole(string fullName, string role, out User userObj);

        /// <summary>
        ///     Validate user by username and password.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">User password.</param>
        /// <param name="isValid">Is User valid.</param>
        /// <returns>Return true if success, else false.</returns>
        bool ValidateUser(string userName, string password, out bool isValid);
    }
}