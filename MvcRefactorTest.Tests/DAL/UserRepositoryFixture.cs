namespace MvcRefactorTest.Tests.DAL
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Moq;

    using MvcRefactorTest.DAL;
    using MvcRefactorTest.DAL.Interface;
    using MvcRefactorTest.Domain;
    using MvcRefactorTest.Domain.db;

    using NUnit.Framework;

    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    #endregion

    [TestFixture]
    public class UserRepositoryFixture
    {
        private Mock<dbContext> _dbContextMock;

        private Mock<IDbSet<User>> _dbSetMock;

        private FakeDbSet<User> _fakeDbSetUser;

        private bool _isValid;

        private IQueryable<User> _userList;

        private User _userObj;

        private UserRepository _userRepository;

        /// <summary>
        ///     Initialize unit tests
        /// </summary>
        /// <param name="userList">userList</param>
        /// <param name="userObj">userObj</param>
        [TestFixtureSetUp]
        public void InitializeUnitTests()
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

            _userList =
                new List<User>
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
                    }.AsQueryable();

            _dbContextMock = new Mock<dbContext>();

            _dbSetMock = new Mock<IDbSet<User>>();

            _fakeDbSetUser = new FakeDbSet<User>();
            foreach (var userObject in _userList.ToList())
            {
                _fakeDbSetUser.Add(userObject);
            }

            _dbSetMock.Setup(m => m.Provider).Returns(_userList.Provider);
            _dbSetMock.Setup(m => m.Expression).Returns(_userList.Expression);
            _dbSetMock.Setup(m => m.ElementType).Returns(_userList.ElementType);
            _dbSetMock.Setup(m => m.GetEnumerator()).Returns(() => _userList.GetEnumerator());
        }

        [TestFixtureTearDown]
        public void TearDownObjects()
        {
            _userList = null;
            _dbContextMock = null;
            _userObj = null;
            _dbContextMock = null;
        }

        [Test]
        public void GetAllActiveUsers()
        {
            // return a user by Name
            _dbSetMock.Setup(x => x.Select(p => p)).Returns(_userList);
            _dbContextMock.Setup(x => x.User).Returns(_dbSetMock.Object as DbSet<User>);

            // dbSetMock.Setup(m => m.Find(1)).Returns(test);

            // setup of Mock User Repository
            var target = _dbContextMock.Object;

            IUserRepository userRepository = new UserRepository(target);
            IList<User> testUserList;
            var success = userRepository.GetAllUsersBy(true, out testUserList);

            // assert
            Assert.AreEqual(true, success);
            Assert.AreNotEqual(2, testUserList.Select(p => p.IsEnabled).Count());
        }

        [Test]
        public void GetAllUers()
        {
            // Return all users
            _dbContextMock.Setup(x => x.User).Returns(_dbSetMock.Object as DbSet<User>);

            // setup of our Mock User Repository
            dbContext target = _dbContextMock.Object;
            IList<User> testUser;
            _userRepository = new UserRepository(target);
            var success = _userRepository.GetAllUsers(out testUser);

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
            _dbContextMock.Setup(mockContext => mockContext.User).Returns(_dbSetMock.Object as DbSet<User>);

            // setup of our Mock User Repository
            var target = _dbContextMock.Object;
            User testUser;
            _userRepository = new UserRepository(target);
            var success = _userRepository.GetUserBy(2, out testUser);

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
            _dbContextMock.Setup(mockContext => mockContext.User).Returns(_dbSetMock.Object as DbSet<User>);

            // setup of Mock User Repository
            var target = _dbContextMock.Object;
            User testUser;
            _userRepository = new UserRepository(target);
            var success = _userRepository.GetUserBy(userName, out testUser);

            // assert
            Assert.AreEqual(true, success);
            if (userName == testUser.Name)
            {
                Assert.AreEqual(userName, testUser.Name);
            }
            else
            {
                Assert.AreNotEqual(userName, testUser.Name);
            }
        }

        [Test]
        [Combinatorial]
        public void ValidateUser(
            [Values("Richard Child", "Chris Smith", "Awin George", "", null)] string userName,
            [Values("pass", "Test Password", "", null)] string password)
        {
            _dbContextMock.Setup(mockContext => mockContext.User).Returns(_dbSetMock.Object as DbSet<User>);

            // return a user by Name
            // _mockUserRepository.Setup(mockContext => mockContext.ValidateUser(It.IsAny<string>(), It.IsAny<string>(), out _isValid))
            // .Returns(true);

            // setup of Mock User Repository
            var target = _dbContextMock.Object;
            bool isValid;
            _userRepository = new UserRepository(target);
            bool success = _userRepository.ValidateUser(userName, password, out isValid);

            // assert
            Assert.AreEqual(true, success);
        }
    }
}