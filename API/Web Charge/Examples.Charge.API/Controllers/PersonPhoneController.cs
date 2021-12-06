using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _personPhoneFacade;

        public PersonPhoneController(IPersonPhoneFacade personPhoneFacade)
        {
            _personPhoneFacade = personPhoneFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get()
        {
            var response = await _personPhoneFacade.FindAllAsync();

            return Response(response);
        }

        [HttpGet("{businessEntityID}/{phoneNumber}/{phoneNumberTypeID}")]
        public async Task<ActionResult<PersonPhoneResponse>> Get(int businessEntityID, string phoneNumber, int phoneNumberTypeID)
        {
            var personPhone = await _personPhoneFacade.Get(businessEntityID, phoneNumber, phoneNumberTypeID);

            return Response(personPhone);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] PersonPhoneDto personPhoneDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = await _personPhoneFacade.Insert(personPhoneDto);

            return Response(id, null);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PersonPhoneCustomDto personPhoneCustomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _personPhoneFacade.Update(personPhoneCustomDto.PersonPhoneDtoOld, personPhoneCustomDto.PersonPhoneDtoNew);

            return Response(new PersonPhoneResponse());
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(PersonPhoneDto personPhoneDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _personPhoneFacade.Delete(personPhoneDto);

            return Response(new PersonPhoneResponse());
        }
    }
}
