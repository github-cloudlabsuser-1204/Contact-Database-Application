using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = userList;

            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<User>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList.Count, model.Count);
            Assert.AreEqual(userList[0].Id, model[0].Id);
            Assert.AreEqual(userList[0].Name, model[0].Name);
            Assert.AreEqual(userList[0].Email, model[0].Email);
            Assert.AreEqual(userList[1].Id, model[1].Id);
            Assert.AreEqual(userList[1].Name, model[1].Name);
            Assert.AreEqual(userList[1].Email, model[1].Email);
        }

        [TestMethod]
        public void Details_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Details(userId) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList[0].Id, model.Id);
            Assert.AreEqual(userList[0].Name, model.Name);
            Assert.AreEqual(userList[0].Email, model.Email);
        }

        [TestMethod]
        public void Create_ReturnsView()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>();
            UserController.userlist = userList;
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Edit(userId) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList[0].Id, model.Id);
            Assert.AreEqual(userList[0].Name, model.Name);
            Assert.AreEqual(userList[0].Email, model.Email);
        }

        [TestMethod]
        public void Edit_Post_UpdatesUserAndRedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = userList;
            var userId = 1;
            var updatedUser = new User { Id = 1, Name = "Updated John", Email = "updatedjohn@example.com" };

            // Act
            var result = controller.Edit(userId, updatedUser) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(updatedUser.Name, userList[0].Name);
            Assert.AreEqual(updatedUser.Email, userList[0].Email);
        }

        [TestMethod]
        public void Delete_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Delete(userId) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList[0].Id, model.Id);
            Assert.AreEqual(userList[0].Name, model.Name);
            Assert.AreEqual(userList[0].Email, model.Email);
        }

        [TestMethod]
        public void Delete_Post_RemovesUserAndRedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = userList;
            var userId = 1;

            // Act
            var result = controller.Delete(userId, null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(1, userList.Count);
            Assert.AreEqual(2, userList[0].Id);
            Assert.AreEqual("Jane", userList[0].Name);
            Assert.AreEqual("jane@example.com", userList[0].Email);
        }
    }
}
