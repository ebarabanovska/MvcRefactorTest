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
    using System;

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
        [TestFixtureSetUp]
        public void InitializeUnitTests()
        {
            // create some mock products to play with
            _userObj = new User
                           {
                               Name = "Chris Smith", 
                               id = 2, 
                               Password = "pass", 
                               Role = "Developer", 
                               IsEnabled = true
                           };

            _userList = new List<User>
                            {
                                _userObj, 
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

            _mockUserRepository = new Mock<IUserRepository>();
        }

        [TestFixtureTearDown]
        public void TearDownObjects()
        {
            _userList = null;
            _userObj = null;
            _mockUserRepository = null;
        }

        [Test]
        public void GetAllsUersTest()
        {
            // Return all users
            _mockUserRepository.Setup(mr => mr.GetAllUsers(out _userList)).Returns(true);

            // setup of our Mock User Repository
            var target = new UserService(_mockUserRepository.Object);
            IList<User> testUser;
            var success = target.GetAllUsers(out testUser);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreEqual(3, testUser.Count);
            Assert.AreNotEqual(null, testUser);
            Assert.AreEqual(
                false, 
                testUser.Where(p => p.Name == "Awin George").Select(p => p.IsDeleted).First());
        }

        [Test]
        public void GetUserByIdTest()
        {
            // Return a user by Id
            _mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<int>(), out _userObj)).Returns(true);

            // setup of our Mock User Repository
            var target = new UserService(_mockUserRepository.Object);
            User testUser;
            var success = target.GetUserBy(2, out testUser);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreEqual("Chris Smith", testUser.Name);
            Assert.AreNotEqual("Richard Child", testUser.Name);
            Assert.AreEqual(2, testUser.id);
        }

        [Test]
        [Combinatorial]
        public void GetUserByNameTest([Values("Richard Child", "Chris Smith", "Awin George", "", null)] string userName)
        {
            // return a user by Name
            _mockUserRepository.Setup(mr => mr.GetUserBy(It.IsIn("Chris Smith"), out _userObj)).Returns(true);

            // setup of Mock User Repository
            var target = new UserService(_mockUserRepository.Object);
            User testUser;
            var success = target.GetUserBy(userName, out testUser);

            // assert
            if (testUser != null && userName == testUser.Name)
            {
                Assert.AreEqual(userName, testUser.Name);
                Assert.AreEqual(true, success);
            }
            else
            {
                Assert.AreEqual(false, success);
            }
        }

        [Test]
        [Combinatorial]
        public void ValidateUser(
            [Values("Richard Child", "Chris Smith", "Awin George", "", null)] string userName, 
            [Values("pass", "Test Password", "", null)] string password)
        {
            // return valid user
            var Valid = true;
            _userObj = _userList.FirstOrDefault(p => p.Name == userName && p.Password == password);
            _mockUserRepository.Setup(
                mr =>
                mr.ValidateUser(
                    It.IsIn(_userObj != null ? _userObj.Name : string.Empty), 
                    It.IsIn(_userObj != null ? _userObj.Password : string.Empty), 
                    out Valid)).Returns(true);

            // setup of Mock User Repository
            var target = new UserService(_mockUserRepository.Object);

            var success = target.ValidateUser(userName, password, out Valid);

            // assert
            if (success)
            {
                Assert.IsTrue(success);
                Assert.AreEqual(true, Valid);
            }
            else Assert.IsTrue(!success);
        }
    }
}