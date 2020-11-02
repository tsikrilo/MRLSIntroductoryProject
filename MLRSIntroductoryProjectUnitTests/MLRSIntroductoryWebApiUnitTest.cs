using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;
using MLRSIntroductoryWebApi.Service;
using Moq;
using MRLSIntroductoryProjectWebApi.Controllers;
using MRLSIntroductoryProjectWebApi.Data;
using System;
using System.Threading.Tasks;

namespace MLSIntroductoryUnitTests
{
    [TestClass]
    public class MLRSIntroductoryWebApiUnitTest
    {
        private UserService _userService;
        private Mock<IUserRepository> _userRepositoryMocked;
        private Mock<IMapper> _mapperMocked;

        private User user = new User()
        {
            Id = 1,
            Name = "Name1",
            Surname = "Surname1",
            Birthdate = new DateTime(1998, 01, 02),
            EmailAddress = "test@test.gr",
            UserTypeId = 1,
            UserTitleId = 1,
            IsActive = true
        };

        private User userInserted = new User()
        {
            Name = "Name1",
            Surname = "Surname1",
            Birthdate = new DateTime(1998, 01, 02),
            EmailAddress = "test@test.gr",
            UserTypeId = 1,
            UserTitleId = 1,
            IsActive = true
        };

        private UserDTO SetupDto(string _name, string _surname, DateTime _birthdate,
            string _emailAddress, int _userTypeId, int _userTitleId, bool _isActive)
        {
            var dto = new UserDTO
            {
                Name = _name,
                Surname = _surname,
                Birthdate = _birthdate,
                EmailAddress = _emailAddress,
                UserTypeId = _userTypeId,
                UserTitleId = _userTitleId,
                IsActive = _isActive
            };
            return dto;
        }

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMocked = new Mock<IUserRepository>(MockBehavior.Strict);
            _mapperMocked = new Mock<IMapper>(MockBehavior.Default);
        }

        /// <summary>
        /// Class: <see cref="_usersController"/>
        /// Method: <see cref="_usersController.PostUser(user)"/>
        /// Test: For input user, method returns OkResult
        /// </summary>
        [TestMethod]
        [TestCategory("Success")]
        public void PostUser_InsertSuccessfully()
        {
            Setup();
            _userService = new UserService(_userRepositoryMocked.Object, _mapperMocked.Object);
            _userRepositoryMocked.Setup(x => x.InsertUser(user)).ReturnsAsync(user);

            Task<ActionResult<User>> response = _userService.CreateUser(user);
            Assert.AreEqual(response.Result.Value.Id, user.Id);
        }

        /// <summary>
        /// Class: <see cref="_usersController"/>
        /// Method: <see cref="_usersController.PostUser(user)"/>
        /// Test: For input null, method returns BadRequest
        /// </summary>
        [TestMethod]
        [TestCategory("Fail")]
        public async Task PostUser_InsertNotSuccessfully_BadRequest()
        {
            Setup();
            User nullUser = null;
            _userService = new UserService(_userRepositoryMocked.Object, _mapperMocked.Object);
            _userRepositoryMocked.Setup(x => x.InsertUser(null)).ReturnsAsync(nullUser);
            try
            {
                var response = await _userService.CreateUser(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("user", ex.ParamName);
            }
        }

        /// <summary>
        /// Class: <see cref="_usersController"/>
        /// Method: <see cref="_usersController.DeleteUser(int)"/>
        /// Test: For input id = 1, method returns user with Id = 1 and IsActive = false
        /// </summary>
        [TestMethod]
        [TestCategory("Success")]
        public void DeleteUser_Successfully()
        {
            Setup();
            User user = new User()
            {
                Id = 1,
                Name = "Name1",
                Surname = "Surname1",
                Birthdate = new DateTime(1998, 01, 02),
                EmailAddress = "test@test.gr",
                UserTypeId = 1,
                UserTitleId = 1,
                IsActive = false
            };
            _userService = new UserService(_userRepositoryMocked.Object, _mapperMocked.Object);
            _userRepositoryMocked.Setup(x => x.DeleteUser(1)).ReturnsAsync(user);

            var response = _userService.DisableUser(1);
            Assert.AreEqual(response.Result.Value.IsActive, user.IsActive);
        }

        /// <summary>
        /// Class: <see cref="_usersController"/>
        /// Method: <see cref="_usersController.DeleteUser(int)"/>
        /// Test: For input id <= 0, method returns BadRequest
        /// </summary>
        [TestMethod]
        [TestCategory("Fail")]
        public async Task DeleteUser_NotSuccessfully_BadRequest()
        {
            Setup();
            User nullUser = null;
            _userService = new UserService(_userRepositoryMocked.Object, _mapperMocked.Object);
            _userRepositoryMocked.Setup(x => x.DeleteUser(-2)).ReturnsAsync(nullUser);
            try
            {
                var response = await _userService.DisableUser(-2);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("id", ex.ParamName);
            }
        }
    }
}
