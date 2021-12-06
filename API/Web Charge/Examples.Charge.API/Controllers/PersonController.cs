using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get()
        {
            var response = await _personFacade.FindAllAsync();

            return Response(response);
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id)
        {
            var person = await _personFacade.Get(id);

            return Response(person);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = await _personFacade.Insert(personDto);

            return Response(id, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _personFacade.Update(id, personDto);

            return Response(new PersonResponse());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _personFacade.Delete(id);

            return Response(new PersonResponse());
        }
    }
}
