using System;

using log4net;

using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Log4Net;

namespace MvcRefactorTest.BL
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        private readonly ILog _logger = LogFactory.GetLogger();

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

            try
            {
                if (this._contactRepository.GetContactDetails(out contactObj)) succeed = true;
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message, ex);
            }

            return succeed;
        }
    }
}