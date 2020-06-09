﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {     
        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "male";
            var birthDate = DateTime.Now.AddYears(- 18);
            var weight = 85;
            var height = 190;
            var controller = new UserController(userName);
            // Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }
    }
}