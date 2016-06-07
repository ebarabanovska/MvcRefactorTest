using System.Collections.Generic;
using System.Linq;

using Moq;

using MvcRefactorTest.BL;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;

using NUnit.Framework;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MvcRefactorTest.Tests.BL
{
    [TestFixture]
    public class UserServiceFixture
    {
        private Mock<IUserRepository> _mockUserRepository;

        private IList<User> _userList;

        private User _userObj;

        /// <summary>
        ///     Initialize unit tests
        /// </summary>
        /// <param name="userList">userList</param>
        /// <param name="userObj">userObj</param>
        /// <param name="mockUserRepository">UserRepository Mock</param>
        private static void InitializeUnitTests(
            out IList<User> userList, 
            out User userObj, 
            out Mock<IUserRepository> mockUserRepository)
        {
            // create some mock products to play with
            userList = new List<User>
                           {
                               new User
                                   {
                                       Name = "Chris Smith", 
                                       Password = "pass", 
                                       Role = "Developer", 
                                       IsEnabled = true, 
                                       id = 2
                                   }, 
                               new User
                                   {
                                       Name = "Awin George", 
                                       Password = "pass", 
                                       Role = "Developer", 
                                       IsEnabled = false, 
                                       id = 3
                                   }, 
                               new User
                                   {
                                       Name = "Richard Child", 
                                       Password = "pass", 
                                       Role = "Developer", 
                                       IsEnabled = true, 
                                       id = 4
                                   }
                           };

            userObj = new User { Name = "Chris Smith", id = 2, Password = "pass", Role = "Developer", IsEnabled = true };

            mockUserRepository = new Mock<IUserRepository>();
        }

        [Test]
        public void GetAllsUersTest()
        {
            InitializeUnitTests(out this._userList, out this._userObj, out this._mockUserRepository);

            // Return all users
            this._mockUserRepository.Setup(mr => mr.GetAllUsers(out this._userList)).Returns(true);

            // setup of our Mock User Repository
            var target = new UserService(this._mockUserRepository.Object);
            IList<User> testUser;
            var success = target.GetAllUsers(out testUser);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreEqual(3, testUser.Count);
            Assert.AreNotEqual(null, testUser);
            Assert.AreEqual(
                false, 
                testUser.Where(p => p.Name == "Awin George").Select(p => p.IsDeleted).SingleOrDefault());
        }

        [Test]
        public void GetUserByIdTest()
        {
            InitializeUnitTests(out this._userList, out this._userObj, out this._mockUserRepository);

            // Return a user by Id
            this._mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<int>(), out this._userObj)).Returns(true);

            // setup of our Mock User Repository
            var target = new UserService(this._mockUserRepository.Object);
            User testUser;
            var success = target.GetUserBy(2, out testUser);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreEqual("Chris Smith", testUser.Name);
            Assert.AreNotEqual("Richard Child", testUser.Name);
            Assert.AreEqual(2, testUser.id);
        }

        [Test]
        public void GetUserByNameTest()
        {
            InitializeUnitTests(out this._userList, out this._userObj, out this._mockUserRepository);

            // return a user by Name
            this._mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<string>(), out this._userObj)).Returns(true);

            // setup of Mock User Repository
            var target = new UserService(this._mockUserRepository.Object);
            User testUser;
            var success = target.GetUserBy("Richard Child", out testUser);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreNotEqual("Richard Child", testUser.Name);
            Assert.AreEqual("Chris Smith", testUser.Name);
        }
    }
}