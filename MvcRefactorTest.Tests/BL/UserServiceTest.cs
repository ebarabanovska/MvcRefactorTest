using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcRefactorTest.BL;
using MvcRefactorTest.DAL;
using MvcRefactorTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.Tests.BL
{
    [TestClass]
    public class UserServiceTest
    {
        #region Private Members

        private IList<User> _userList;
        private User _userObj;
        private Mock<IUserRepository> _mockUserRepository;

        /// <summary>
        /// Initialize unit tests
        /// </summary>
        /// <param name="userList">userList</param>
        /// <param name="userObj">userObj</param>
        /// <param name="mockUserRepository">UserRepository Mock</param>
        private static void InitializeUnitTests(out IList<User> userList, out User userObj, out Mock<IUserRepository> mockUserRepository)
        {
            // create some mock products to play with
            userList = new List<User>
                {
                    new User  { name = "Chris Smith", password = "pass", role = "Developer", isEnabled = true },
                    new User { name = "Awin George", password = "pass", role = "Developer", isEnabled = false },
                    new User { name = "Richard Child", password = "pass", role = "Developer", isEnabled = true }
                };

            userObj = new User { name = "Chris Smith", id = 2, password = "pass", role = "Developer", isEnabled = true };

            mockUserRepository = new Mock<IUserRepository>();
        }

        #endregion

        #region UnitTests

        [TestMethod]
        public void GetAllsUersTest()
        {

            InitializeUnitTests(out _userList, out _userObj, out _mockUserRepository);

            // Return all users
            _mockUserRepository.Setup(mr => mr.GetAllUsers(out _userList)).Returns(true);

            // setup of our Mock User Repository
            var target = new UserService(_mockUserRepository.Object);
            IList<User> testUser;
            bool result = target.GetAllUsers(out testUser);

            //assert
            Assert.AreEqual(3, testUser.Count);
            Assert.AreNotEqual(null, testUser);
            Assert.AreEqual(false, testUser.Where(p => p.name == "Awin George").Select(p => p.isDeleted).SingleOrDefault());
        }

        [TestMethod]
        public void GetUserByIdTest()
        {

            InitializeUnitTests(out _userList, out _userObj, out _mockUserRepository);

            // Return a user by Id
            _mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<int>(), out _userObj)).Returns(true);

            // setup of our Mock User Repository
            var target = new UserService(_mockUserRepository.Object);
            User testUser;
            bool result = target.GetUserBy("Chris Smith", out testUser);

            //assert
            Assert.AreEqual("Chris Smith", testUser.name);
            Assert.AreNotEqual("Richard Child", testUser.name);
            Assert.AreEqual(2, testUser.id);
        }

        [TestMethod]
        public void GetUserByNameTest()
        {
            InitializeUnitTests(out _userList, out _userObj, out _mockUserRepository);

            // return a user by Name
            _mockUserRepository.Setup(mr => mr.GetUserBy(It.IsAny<string>(), out _userObj)).Returns(true);

            // setup of Mock User Repository
            var target = new UserService(_mockUserRepository.Object);
            User testUser;
            bool result = target.GetUserBy("Richard Child", out testUser);

            //assert
            Assert.AreEqual("Chris Smith", testUser.name);
            Assert.AreNotEqual("Richard Child", testUser.name);
            Assert.AreEqual(2, testUser.id);

        }

        #endregion
    }
}
