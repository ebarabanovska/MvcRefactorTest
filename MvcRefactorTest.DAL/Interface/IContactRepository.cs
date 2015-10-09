using System;
namespace MvcRefactorTest.DAL
{
    public interface IContactRepository
    {
        /// <summary>
        /// Get Contact Details
        /// </summary>
        /// <returns>Returns true if success, else false</returns>
        bool GetContactDetails(out MvcRefactorTest.Domain.Contact contactObj);
    }
}
