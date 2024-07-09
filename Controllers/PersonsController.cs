using Microsoft.AspNetCore.Mvc;
using PersonsApi.DTOs;
using PersonsApi.Services;

namespace PersonsApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly PersonService _personService;

    public PersonsController(PersonService personService)
    {
        _personService = personService;
    }

    // GET: api/v1/persons/{id}
    [HttpGet("{id}")]
    public ActionResult<DUser> Get(int id)
    {
        try
        {
            return this.Ok(_personService.Get(id));
        }
        catch (InvalidOperationException e)
        {
            return NotFound("The selected person cannot be found");
        }
    }

    // GET: api/v1/persons?term=something
    [HttpGet]
    public ActionResult<Pagination<DUser>> Get([FromQuery] string? term, [FromQuery] PaginationParam paginationParam)
    {
        return this.Ok(_personService.Get(term, paginationParam));
    }

    [HttpPost]
    public ActionResult<DUser> Add([FromBody] DUser dUser)
    {
        return this.Ok(_personService.Add(dUser));
    }

    [HttpPut("{id}")]
    public ActionResult<DUser> Update(int id, [FromBody] DUser dUser)
    {
        dUser.Id = id;
        return this.Ok(_personService.Update(dUser));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _personService.Delete(id);
        return this.Ok();
    }
}