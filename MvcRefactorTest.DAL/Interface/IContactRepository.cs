using MvcRefactorTest.Domain;

namespace MvcRefactorTest.DAL.Interface
{
    public interface IContactRepository
    {
        /// <summary>
        ///     Get Contact Details
        /// </summary>
        /// <returns>Returns true if success, else false</returns>
        bool GetContactDetails(out Contact contactObj);
    }
}