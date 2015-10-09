using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRefactorTest;
using MvcRefactorTest.Controllers;
using Moq;
using MvcRefactorTest.DAL;
using System.Web;
using System.Web.Routing;
using MvcRefactorTest.Domain;

namespace MvcRefactorTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //protected Mock<HttpContextBase> HttpContextBaseMock;
        //protected Mock<HttpRequestBase> HttpRequestMock;
        //protected Mock<HttpResponseBase> HttpResponseMock;
        //protected Mock<IUserRepository> UserRepositoryMock;
        //protected Mock<IContactRepository> ContactRepositoryMock;


        //private HomeController CreateInstance()
        //{
        //    //return new HomeController(UserRepositoryMock.Object, ContactRepositoryMock.Object);
        //}

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    HttpContextBaseMock = new Mock<HttpContextBase>();
        //    HttpRequestMock = new Mock<HttpRequestBase>();
        //    HttpResponseMock = new Mock<HttpResponseBase>();
        //    UserRepositoryMock = new Mock<IUserRepository>();
        //    ContactRepositoryMock = new Mock<IContactRepository>();

        //    HttpContextBaseMock.SetupGet(x => x.Request).Returns(HttpRequestMock.Object);
        //    HttpContextBaseMock.SetupGet(x => x.Response).Returns(HttpResponseMock.Object);

        //    //UserRepositoryMock.SetupGet(x => x.ValidateUser).Returns(x);
        //}

        //protected HomeController SetupController()
        //{
        //    //var routes = new RouteCollection();

        //    //var controller = new HomeController(UserRepositoryMock.Object, ContactRepositoryMock.Object);
        //    //controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);
        //    //controller.Url = new UrlHelper(new RequestContext(HttpContextBaseMock.Object, new RouteData()), routes);
        //    //return controller;
        //}

        //[TestMethod]
        //public void IndexTest()
        //{
        //    // act
        //    //var controller = new HomeController(UserRepositoryMock.Object, ContactRepositoryMock.Object);
        //    //ViewResult model = (ViewResult)controller.Index();
        //    //var result = model.Model;

        //    //// setup
        //    //var application = new ApplicationBuilder().WithName("Name").WithDefaultTeam().Build();
        //    //// act
        //    //var model = new ApplicationViewModel(application);
        //    //// verify
        //    //Assert.AreEqual(application.Id, model.Id);
        //    //Assert.AreEqual(application.Name, model.Name);
        //    //Assert.AreEqual(application.Description, model.Description);
        //    //Assert.AreEqual(application.TeamId, model.TeamId);
        //    //Assert.AreEqual(application.Team.Name, model.TeamName);
        //}








        //[TestMethod]
        //public void Index()
        //{
        //    //Mock<IUserRepository> mockUserRepo = new Mock<IUserRepository>();
        //    //Mock<IContactRepository> mockContactRepo = new Mock<IContactRepository>();

        //    //bool isValid = false;
        //    //mockUserRepo.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>(), out isValid)).Returns<bool>(total => total);
        //    //mockContactRepo.Setup(m => m.(It.IsAny<string>(), It.IsAny<string>(), out isValid)).Returns<bool>(total => total);

        //    //var target = new HomeController(mockUserRepo.Object, mockContactRepo.Object);

        //    //var result = target.Index();




        //    var request = new Mock<HttpRequestBase>();
        //    request.Setup(r => r.HttpMethod).Returns("GET");
        //    var mockHttpContext = new Mock<HttpContextBase>();
        //    mockHttpContext.Setup(c => c.Request).Returns(request.Object);
        //    var controllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), new Mock<ControllerBase>().Object);



        //}

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    //HomeController controller = new HomeController();

        //    // Act
        //    //ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    //Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    //HomeController controller = new HomeController();

        //    // Act
        //    //ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    //Assert.IsNotNull(result);
        //}
    }
}
