using Application.Contracts.UserContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;
using Newtonsoft.Json;

namespace Recipe.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _userApplication.SelectAllUsers();
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userApplication.FindUser(u => u.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromQuery] string username, string email, string password)
        {
            int? userId;
            var isSuccess = _userApplication.AddUser(new CreateUserCommand
            {
                Email = email,
                Password = password,
                Username = username
            }, out userId);
            if (userId.HasValue && isSuccess)
            {
                var url = Url.Action(nameof(Get), "User", new { id = userId }, Request.Scheme);
                return Created(url, userId);
            }
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserCommand userCmd)
        {
            bool isSuccesed = false;
            isSuccesed = _userApplication.Update(userCmd);
            //Restful api rules must be followed
            //if the object is not exists in put request so it should be generated
            if (!isSuccesed)
            {
                var createcmd = new CreateUserCommand
                {
                    Email = userCmd.Email,
                    Password = userCmd.Password,
                    Username = userCmd.Username,
                };
                int? newid;
                isSuccesed = _userApplication.AddUser(createcmd, out newid);
            }
            if (isSuccesed)
                return Ok();

            return BadRequest();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userApplication.DeActiveUser(id);
            if(result)
                return Ok();

            return NotFound();
        }
    }
}
