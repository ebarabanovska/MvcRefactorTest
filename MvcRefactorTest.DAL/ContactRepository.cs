using log4net;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Domain.db;
using MvcRefactorTest.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.DAL
{
    public class ContactRepository : MvcRefactorTest.DAL.IContactRepository
    {
        private dbContext _context;
        private readonly ILog logger = LogFactory.GetLogger();

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
                using (_context = new dbContext())
                {
                    contactObj = _context.Contact.FirstOrDefault();
                    succeed = true;
                }
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
