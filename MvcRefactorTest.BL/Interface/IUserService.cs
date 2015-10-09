using System;
namespace MvcRefactorTest.BL.Interface
{
    public interface IUserService
    {
        bool ChangePassword(string fullName, string password);
        bool CreateUser(string fullName, string password, string role, out MvcRefactorTest.Domain.User userObj);
        bool GetAllUsers(out System.Collections.Generic.IList<MvcRefactorTest.Domain.User> userList);
        bool GetAllUsersBy(bool active, out System.Collections.Generic.IList<MvcRefactorTest.Domain.User> userList);
        bool GetUserBy(int id, out MvcRefactorTest.Domain.User userObj);
        bool GetUserBy(string name, out MvcRefactorTest.Domain.User userObj);
        bool RemoveUserFromRole(string fullName, string role, out MvcRefactorTest.Domain.User userObj);
        bool ValidateUser(string userName, string password, out bool isValid);
    }
}
