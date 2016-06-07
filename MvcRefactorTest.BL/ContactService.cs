using System;

using log4net;

using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.Common;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;

namespace MvcRefactorTest.BL
{
    [LoggingAspect]
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        /// <summary>
        ///     Contact Servce default constructor.
        /// </summary>
        /// <param name="contactRepository">Injected contact Repository.</param>
        public ContactService(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        /// <summary>
        ///     Get Contact Details.
        /// </summary>
        /// <returns>Returns true if success, else false.</returns>
        public bool GetContactDetails(out Contact contactObj)
        {
            var succeed = false;
            contactObj = null;

            if (this._contactRepository.GetContactDetails(out contactObj)) succeed = true;

            return succeed;
        }
    }
}