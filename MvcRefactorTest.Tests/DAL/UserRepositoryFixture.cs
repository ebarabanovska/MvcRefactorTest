using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;

using NUnit.Framework;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MvcRefactorTest.Tests.DAL
{
    using System;

    [TestFixture]
    public class UserRepositoryFixture
    {
        private static bool _isValid;

        private static Mock<IUserRepository> _mockUserRepository;

        private static IList<User> _userList;

        private static User _userObj;

        /// <summary>
        ///     Initialize unit tests
        /// </summary>
        /// <param name="userList">userList</param>
        /// <param name="userObj">userObj</param>
        [TestFixtureSetUp]
        public static void InitializeUnitTests()
        {
            // create some mock products to play with
            _isValid = true;

            _userObj = new User
                           {
                               Name = "Chris Smith",
                               Password = "pass",
                               Role = "Developer",
                               IsEnabled = true,
                               id = 2
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
            _mockUserRepository = null;
        }

        [Test]
        public void GetAllActiveUsersBy()
        {
            // return a user by Name
            _mockUserRepository.Setup(mr => mr.GetAllUsersBy(It.IsAny<bool>(), out _userList)).Returns(true);

            // setup of Mock User Repository
            var target = _mockUserRepository.Object;
            IList<User> testUserList;
            var success = target.GetAllUsersBy(true, out testUserList);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreNotEqual(2, testUserList.Select(p => p.IsEnabled).Count());
        }

        [Test]
        public void GetAllsUersTest()
        {
            // Return all users
            _mockUserRepository.Setup(mr => mr.GetAllUsers(out _userList)).Returns(true);

            // setup of our Mock User Repository
            var target = _mockUserRepository.Object;
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
            // Return a user by Id
            _mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<int>(), out _userObj)).Returns(true);

            // setup of our Mock User Repository
            var target = _mockUserRepository.Object;
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
            _mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<string>(), out _userObj)).Returns(true);

            // setup of Mock User Repository
            var target = _mockUserRepository.Object;
            User testUser;
            var success = target.GetUserBy(userName, out testUser);

            // assert
            Assert.AreEqual(true, success);
            if (userName == testUser.Name) Assert.AreEqual(userName, testUser.Name);
            else Assert.AreNotEqual(userName, testUser.Name);
        }

        [Test]
        [Combinatorial]
        public void ValidateUser([Values("Richard Child", "Chris Smith", "Awin George", "", null)] string userName,
            [Values("pass", "Test Password", "", null)] string password)
        {

            var mockDelegate = new Mock<Func<IUserRepository>>();

            Func<IUserRepository> mockDelegatetest = () => _mockUserRepository.Object;
            mockDelegate.Setup(x => x()).Returns(_mockUserRepository.Object);

            var success = _mockUserRepository.Object.ValidateUser(userName, password, out _isValid);

            // return a user by Name
            //_mockUserRepository.Setup(mr => mr.ValidateUser(It.IsAny<string>(), It.IsAny<string>(), out _isValid))
            //    .Returns(true);

            // setup of Mock User Repository
            //var target = _mockUserRepository.Object;
            //bool isValid;
            // = target.ValidateUser(userName, password, out isValid);

            // assert
            //Assert.AreEqual(true, success);
            Assert.AreEqual(true, _isValid);
        }
    }
}