using RealEstate.DataAccess;
using RealEstate.Helpers;
using RealEstate.Models;
using RealEstate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealEstate.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Register([FromBody] User_VM_Register viewModel)
        {
            try
            {
                int returnValue = UserService.Users_Insert(viewModel.ConvertToModel());

                if (returnValue == -1)
                {
                    return BadRequest("Username already exists in database.");
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
        [HttpPost]
        public IHttpActionResult Login([FromBody] User_VM_Login viewModel)
        {
            try
            {
                List<User> users = UserService.Users_Select(username: viewModel.Username);
                if (users == null || users.Count == 0)
                {
                    return BadRequest("Username does not exist in database.");
                }

                User user = users[0];

                viewModel.Password = user.HashedPassword(viewModel.Password);
                if (user.Password != viewModel.Password)
                {
                    return BadRequest("Please input the correct password.");
                }

                return Ok(MyToken.TokenGeneration(user));
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            User_VM_Get viewModel = new User_VM_Get(UserService.Users_Select(MyToken.GetUserID(token))[0]);

            return Ok(viewModel);
        }
        [MyAuthorize]
        [HttpPut]
        public IHttpActionResult Update([FromBody] User_VM_Update viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                User user = UserService.Users_Select(MyToken.GetUserID(token))[0];

                user.Firstname = viewModel.Firstname;
                user.Lastname = viewModel.Lastname;
                user.Username = viewModel.Username;
                user.Phone = viewModel.Phone;

                int returnValue = UserService.Users_Update(user);

                if (returnValue == -1)
                {
                    return BadRequest("Username already exists in database.");
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
    }
}
