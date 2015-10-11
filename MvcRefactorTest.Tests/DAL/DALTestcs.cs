using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcRefactorTest.DAL;
using MvcRefactorTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcRefactorTest.DAL.Interface;

namespace MvcRefactorTest.Tests.DAL
{
    [TestClass]
    public class DALTestcs
    {

        protected Mock<User> UserMock;
        protected Mock<IList<User>> UserListMock;
        protected Mock<IUserRepository> UserRepositoryMock;

        private IList<User> userTestList = new List<User>{
        new User() { Name = "Awin George", Password = "pass", Role = "Developer", IsEnabled = false },
        new User() { Name = "Richard Child", Password = "pass", Role = "Developer", IsEnabled = true }
        };

        private IUserRepository CreateUserRepoInstance()
        {
            return new UserRepository();
        }

        private IContactRepository CreateContactRepoInstance()
        {
            return new ContactRepository();
        }


        [TestMethod]
        public void GetAllUsers()
        {
            IList<User> userList = new List<User>();
            //UserRepositoryMock = new Mock<IUserRepository>();
            //UserRepositoryMock.Setup(m => m.GetAllUsers(out userList)).Returns<bool>(total => total);

            var target = CreateUserRepoInstance();
            // act             
            bool result = target.GetAllUsers(out userList);

            // verify
            Assert.AreEqual(true, result);
            Assert.AreEqual(3, userList.Count);
            Assert.AreEqual("Awin George", userList.Where(p => p.id == 2).Select(p => p.Name).SingleOrDefault());
        }

        [TestMethod]
        public void GetAllActiveUsersBy()
        {
            IList<User> userList = new List<User>();

            var target = CreateUserRepoInstance();

            // act             
            bool result = target.GetAllUsersBy(true, out userList);

            // verify
            Assert.AreEqual(true, result);
            Assert.AreEqual(2, userList.Count);
            Assert.AreEqual(null, userList.Where(p => p.id == 2).SingleOrDefault());
        }

        [TestMethod]
        public void GetUserBy()
        {
            string name = "Chris Smith";
            User user = new User();

            var target = CreateUserRepoInstance();

            // act             
            bool result = target.GetUserBy(name, out user);

            // verify
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, user.id);
            Assert.AreEqual(true, user.IsEnabled);
            Assert.AreNotEqual(true, user.IsDeleted);
        }

        [TestMethod]
        public void ChangePassword()
        {
            string fullName = "Chris Smith";
            string newPassword = "testPass";
            User user;

            var target = CreateUserRepoInstance();

            // act             
            bool result = target.ChangePassword(fullName, newPassword);

            // verify
            Assert.AreEqual(true, result);

            result = target.GetUserBy(fullName, out user);

            // verify
            Assert.AreEqual(true, result);
            Assert.AreEqual(newPassword, user.Password);
        }

        [TestMethod]
        public void GetContactDetails()
        {
            string fullName = "Chris Smith";
            string newPassword = "testPass";
            Contact contact;

            var target = CreateContactRepoInstance();

            // act             
            bool result = target.GetContactDetails(out contact);

            // verify
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, contact.id);
        }

    }
}

    
