using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcRefactorTest.BL;
using MvcRefactorTest.BL.Interface;
using MvcRefactorTest.DAL;
using MvcRefactorTest.Domain;

namespace MvcRefactorTest.Tests.BL
{
    [TestClass]
    public class UserServiceTest
    {
        #region Private Members

        private IList<User> _userList;
        private User _userObj;
        private Mock<IUserService> _mockUserService;

        /// <summary>
        ///     Initialize unit tests
        /// </summary>
        /// <param name="userList">userList</param>
        /// <param name="userObj">userObj</param>
        /// <param name="mockUserService">UserRepository Mock</param>
        private static void InitializeUnitTests(out IList<User> userList, out User userObj,
            out Mock<IUserService> mockUserService)
        {
            // create some mock products to play with
            userList = new List<User>
            {
                new User {Name = "Chris Smith", Password = "pass", Role = "Developer", IsEnabled = true, id = 2},
                new User {Name = "Awin George", Password = "pass", Role = "Developer", IsEnabled = false, id = 3},
                new User {Name = "Richard Child", Password = "pass", Role = "Developer", IsEnabled = true, id = 4}
            };

            userObj = new User {Name = "Chris Smith", id = 2, Password = "pass", Role = "Developer", IsEnabled = true};

            mockUserService = new Mock<IUserService>();
        }

        #endregion

        #region UnitTests

        [TestMethod]
        public void GetAllsUersTest()
        {
            InitializeUnitTests(out _userList, out _userObj, out _mockUserService);

            // Return all users
            _mockUserService.Setup(mr => mr.GetAllUsers(out _userList)).Returns(true);

            // setup of our Mock User Repository
            //var target = new UserService(_mockUserService.Object);
            IList<User> testUser;
            var result = _mockUserService.Object.GetAllUsers(out testUser);

            //assert
            Assert.AreEqual(3, testUser.Count);
            Assert.AreNotEqual(null, testUser);
            Assert.AreEqual(false,
                testUser.Where(p => p.Name == "Awin George").Select(p => p.IsDeleted).SingleOrDefault());
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            InitializeUnitTests(out _userList, out _userObj, out _mockUserService);

            // Return a user by Id
            _mockUserService.Setup(mr => mr.GetUserBy(It.IsAny<int>(), out _userObj)).Returns(true);

            // setup of our Mock User Repository
            //var target = new UserService(_mockUserService.Object);
            User testUser;
            var result = _mockUserService.Object.GetUserBy("Chris Smith", out testUser);

            //assert
            Assert.AreEqual("Chris Smith", testUser.Name);
            Assert.AreNotEqual("Richard Child", testUser.Name);
            Assert.AreEqual(2, testUser.id);
        }

        [TestMethod]
        public void GetUserByNameTest()
        {
            InitializeUnitTests(out _userList, out _userObj, out _mockUserService);

            // return a user by Name
            _mockUserService.Setup(mr => mr.GetUserBy(It.IsAny<string>(), out _userObj)).Returns(true);

            // setup of Mock User Repository
            //var target = new UserService(_mockUserService.Object);
            User testUser;
            var result = _mockUserService.Object.GetUserBy("Richard Child", out testUser);

            //assert
            Assert.AreEqual("Chris Smith", testUser.Name);
            Assert.AreNotEqual("Richard Child", testUser.Name);
            Assert.AreEqual(2, testUser.id);
        }

        #endregion
    }
}