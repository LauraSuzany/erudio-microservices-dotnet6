using erudio_microservices_dotnet6.Model;
using erudio_microservices_dotnet6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace erudio_microservices_dotnet6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
            private readonly ILogger<CalculatorController> _logger;
            private IPersonService _personService;
            
            
            public PersonController(ILogger<CalculatorController> logger, IPersonService personService)
            {
                _logger = logger;
                _personService = personService;
            }

            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    List<Model.PersonModel> person = _personService.FindAll();
                    return Ok(person);
                }
                catch (Exception ex)
                {
                throw new Exception("Error", ex);
                }
            }

            [HttpGet("{id}")]
            public IActionResult FindById(long id)
            {
                try
                {
                    Model.PersonModel person = _personService.FindById(id);
                    if (person == null)
                    {
                        return NotFound();
                    }
                    
                    return Ok(person);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error", ex);
                }
            } 
        
            [HttpPost]
            public IActionResult Created([FromBody] PersonModel person)
            {
                try
                {
                    person = _personService.Create(person);
                    if (person == null)
                    {
                        return BadRequest();
                    }
                    
                    return Ok(person);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error", ex);
                }
            }

            [HttpPut]
            public IActionResult UpdatePerson([FromBody] PersonModel person)
            {
                try
                {
                    person = _personService.Update(person);
                    if (person == null)
                    {
                        return BadRequest();
                    }
                    
                    return Ok(person);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error", ex);
                }
            }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            try
            {
                _personService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
