using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcRefactorTest.BL;
using MvcRefactorTest.DAL.Interface;
using MvcRefactorTest.Domain;

namespace MvcRefactorTest.Tests.BL
{
    [TestClass]
    public class UserRepositoryTest
    {
        #region Private Members

        private IList<User> _userList;
        private User _userObj;
        private Mock<IUserRepository> _mockUserRepository;

        /// <summary>
        ///     Initialize unit tests
        /// </summary>
        /// <param name="userList">userList</param>
        /// <param name="userObj">userObj</param>
        /// <param name="mockUserRepository">UserRepository Mock</param>
        private static void InitializeUnitTests(out IList<User> userList, out User userObj,
            out Mock<IUserRepository> mockUserRepository)
        {
            // create some mock products to play with
            userList = new List<User>
            {
                new User {Name = "Chris Smith", Password = "pass", Role = "Developer", IsEnabled = true, id = 2},
                new User {Name = "Awin George", Password = "pass", Role = "Developer", IsEnabled = false, id = 3},
                new User {Name = "Richard Child", Password = "pass", Role = "Developer", IsEnabled = true, id = 4}
            };

            userObj = new User {Name = "Chris Smith", id = 2, Password = "pass", Role = "Developer", IsEnabled = true};

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
            var success = target.GetAllUsers(out testUser);

            //assert
            Assert.AreEqual(true, success);
            Assert.AreEqual(3, testUser.Count);
            Assert.AreNotEqual(null, testUser);
            Assert.AreEqual(false,
                testUser.Where(p => p.Name == "Awin George").Select(p => p.IsDeleted).SingleOrDefault());
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
            var success = target.GetUserBy(2, out testUser);

            //assert
            Assert.AreEqual(true, success);
            Assert.AreEqual("Chris Smith", testUser.Name);
            Assert.AreNotEqual("Richard Child", testUser.Name);
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
            var success = target.GetUserBy("Richard Child", out testUser);

            //assert
            Assert.AreEqual(true, success);
            Assert.AreNotEqual("Richard Child", testUser.Name);
            Assert.AreEqual("Chris Smith", testUser.Name);
        }

        #endregion
    }
}