using System;
namespace MvcRefactorTest.Infrastructure.Abstract
{
    public interface ICustomMembershipProvider
    {
        string ApplicationName { get; set; }
        bool ChangePassword(string username, string oldPassword, string newPassword);
        bool Authenticate(string username, string password);
        bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);
        System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status);
        bool DeleteUser(string username, bool deleteAllRelatedData);
        bool EnablePasswordReset { get; }
        bool EnablePasswordRetrieval { get; }
        System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);
        System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);
        System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);
        int GetNumberOfUsersOnline();
        string GetPassword(string username, string answer);
        System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline);
        System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline);
        string GetUserNameByEmail(string email);
        int MaxInvalidPasswordAttempts { get; }
        int MinRequiredNonAlphanumericCharacters { get; }
        int MinRequiredPasswordLength { get; }
        int PasswordAttemptWindow { get; }
        System.Web.Security.MembershipPasswordFormat PasswordFormat { get; }
        string PasswordStrengthRegularExpression { get; }
        bool RequiresQuestionAndAnswer { get; }
        bool RequiresUniqueEmail { get; }
        string ResetPassword(string username, string answer);
        bool UnlockUser(string userName);
        void UpdateUser(System.Web.Security.MembershipUser user);
        bool ValidateUser(string username, string password);
    }
}
