using log4net;
using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.DAL;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.BL
{
    public class ContactService : IContactService
    {
        #region Private Members

        private IContactRepository _contactRepository;
        private readonly ILog logger = LogFactory.GetLogger();

        #endregion

        #region Constructor

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        #endregion

        #region Get methods

        /// <summary>
        /// Get Contact Details
        /// </summary>
        /// <returns>Returns true if success, else false</returns>
        public bool GetContactDetails(out Contact contactObj)
        {
            bool succeed = false;
            contactObj = null;

            try
            {
                if (_contactRepository.GetContactDetails(out contactObj))
                    succeed = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return succeed;
        }

        #endregion
    }
}
