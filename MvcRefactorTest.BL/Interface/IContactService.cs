using MvcRefactorTest.Domain;
using System;
namespace MvcRefactorTest.BL.Interface
{
    public interface IContactService
    {
        /// <summary>
        /// Get Contact Details
        /// </summary>
        /// <returns>Returns true if success, else false</returns>
        bool GetContactDetails(out Contact contactObj);
    }
}
