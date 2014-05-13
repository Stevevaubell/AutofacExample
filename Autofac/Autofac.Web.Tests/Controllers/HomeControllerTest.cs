using AutofacExample.Core.Model;
using AutofacExample.Core.Service;
using AutofacExample.Web.Controllers;
using FizzWare.NBuilder;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace AutofacExample.Web.Tests.Controllers
{
    public class HomeControllerTest
    {
        private HomeController _controller;
        private Mock<IDataService> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IDataService>();
            _controller = new HomeController(_mock.Object);
        }

        [Test]
        public void Index()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_Loads_Contacts()
        {
            // Arrange
            _mock.Setup(x => x.GetAll()).Returns(Builder<Contact>.CreateListOfSize(5).Build());

            // Act
            _controller.Index();

            // Assert
            _mock.Verify(x => x.GetAll());
        }
    }
}
