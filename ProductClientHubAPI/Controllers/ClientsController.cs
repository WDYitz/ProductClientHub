using ProductClientHubAPI.Http.Requests;
using ProductClientHubAPI.Http.Responses;
using Microsoft.AspNetCore.Mvc;
using ProductClientHubAPI.UseCases.Clients.Register;
using ProductClientHubAPI.ExceptionsBase;

namespace ProductClientHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
  public IActionResult Register([FromBody] RequestClientJson request)
  {
    var registerClientUseCase = new RegisterClientUseCase();
    var response = registerClientUseCase.Execute(request);

    return Created(string.Empty, response);
  }

  [HttpPut]
  public IActionResult Update()
  {
    return Ok("Client Updated");
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok("All Clients...");
  }

  [HttpGet]
  [Route("{id}")]
  public IActionResult GetById([FromRoute] Guid id)
  {
    return Ok();
  }

  [HttpDelete]
  public IActionResult Delete()
  {
    return Ok("Client deleted");
  }
}