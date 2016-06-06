using System.Web.Security;

namespace MvcRefactorTest.Infrastructure.Abstract
{
    public interface ICustomMembershipProvider
    {
        string ApplicationName { get; set; }

        bool EnablePasswordReset { get; }

        bool EnablePasswordRetrieval { get; }

        int MaxInvalidPasswordAttempts { get; }

        int MinRequiredNonAlphanumericCharacters { get; }

        int MinRequiredPasswordLength { get; }

        int PasswordAttemptWindow { get; }

        MembershipPasswordFormat PasswordFormat { get; }

        string PasswordStrengthRegularExpression { get; }

        bool RequiresQuestionAndAnswer { get; }

        bool RequiresUniqueEmail { get; }

        bool ChangePassword(string username, string oldPassword, string newPassword);

        bool Authenticate(string username, string password);

        bool ChangePasswordQuestionAndAnswer(
            string username, 
            string password, 
            string newPasswordQuestion, 
            string newPasswordAnswer);

        MembershipUser CreateUser(
            string username, 
            string password, 
            string email, 
            string passwordQuestion, 
            string passwordAnswer, 
            bool isApproved, 
            object providerUserKey, 
            out MembershipCreateStatus status);

        bool DeleteUser(string username, bool deleteAllRelatedData);

        MembershipUserCollection FindUsersByEmail(
            string emailToMatch, 
            int pageIndex, 
            int pageSize, 
            out int totalRecords);

        MembershipUserCollection FindUsersByName(
            string usernameToMatch, 
            int pageIndex, 
            int pageSize, 
            out int totalRecords);

        MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);

        int GetNumberOfUsersOnline();

        string GetPassword(string username, string answer);

        MembershipUser GetUser(object providerUserKey, bool userIsOnline);

        MembershipUser GetUser(string username, bool userIsOnline);

        string GetUserNameByEmail(string email);

        string ResetPassword(string username, string answer);

        bool UnlockUser(string userName);

        void UpdateUser(MembershipUser user);

        bool ValidateUser(string username, string password);
    }
}