using System;
using System.Linq;
using log4net;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;
using MvcRefactorTest.Domain.db;
using MvcRefactorTest.Log4Net;

namespace MvcRefactorTest.DAL
{
    public class ContactRepository : IContactRepository
    {
        private readonly ILog _logger = LogFactory.GetLogger();
        private dbContext _context;

        #region Get methods

        /// <summary>
        ///     Get Contact Details
        /// </summary>
        /// <returns>Returns true if success, else false</returns>
        public bool GetContactDetails(out Contact contactObj)
        {
            var succeed = false;
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
                _logger.Error(ex.Message, ex);
            }

            return succeed;
        }
        
        #endregion
    }
}