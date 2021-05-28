using System.Collections.Generic;
using System.Net.Mime;
using generate_card.Entity;
using generate_card.Repository;
using generate_card.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generate_card.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(string email)
        {
            return _userService.GetOne(email);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Create(User user)
        {
            return _userService.Create(user);
        }
        
        [HttpDelete("{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(string email)
        {
            _userService.Delete(email);
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<User>> GetAllFullUsers()
        {
            return _userService.GetAllFullUsers();
        }

    }
}