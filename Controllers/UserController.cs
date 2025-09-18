using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Communication.Requests;
using MyFirstAPI.Communication.Responses;

namespace MyFirstAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id)
    {
        var response = new User
        {
            Id = id,
            Name = "John Doe",
            Age = 30
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RequestRegisterUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Create([FromBody] RequestRegisterUserJson requestRegisterUserJson)
    {
        var response = new ResponseRegisterUserJson
        {
            Id = new Random().Next(1, 1000), // Simulate ID generation
            Name = requestRegisterUserJson.Name,
        };

        // In a real application, you would save the user to a database here.
        return Created(string.Empty, response);
    }
}
