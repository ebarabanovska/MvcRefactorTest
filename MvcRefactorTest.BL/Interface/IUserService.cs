using System.Collections.Generic;
using MvcRefactorTest.Domain;

namespace MvcRefactorTest.BL.Interface
{
    public interface IUserService
    {
        bool ChangePassword(string fullName, string password);

        bool CreateUser(string fullName, string password, string role, out User userObj);

        bool GetAllUsers(out IList<User> userList);

        bool GetAllUsersBy(bool active, out IList<User> userList);

        bool GetUserBy(int id, out User userObj);

        bool GetUserBy(string name, out User userObj);

        bool RemoveUserFromRole(string fullName, string role, out User userObj);

        bool ValidateUser(string userName, string password, out bool isValid);
    }
}