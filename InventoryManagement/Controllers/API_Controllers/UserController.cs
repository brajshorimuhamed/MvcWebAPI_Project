using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Entities._DTO;
using InventoryManagement.Models.Services_BL.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.API_Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public List<UserData> Get()
        {
            return _userService.GetUsers();
        }

        // GET: api/User/5
        [HttpGet("{Id}", Name = "GetUser")]
        public UserData GetUser(int Id)
        {
            return _userService.GetUserById(Id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult PostUser([FromBody] UserSubmissionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not valid model");

            _userService.AddUser(model);

            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{Id}")]
        public IActionResult PutUser(int Id, [FromBody] UserUpdateSubmissionModel userData)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not valid model");

            var userId = _userService.GetUserById(Id);

            if (userId != null)
            {
                _userService.UpdateUser(userData);

                return Ok();
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var user = _userService.GetUserById(Id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(user.Id);

            return NoContent();
        }
    }
}
