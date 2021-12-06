using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberTypeController : BaseController
    {
        private IPhoneNumberTypeFacade _phoneNumberTypeFacade;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade phoneNumberTypeFacade)
        {
            _phoneNumberTypeFacade = phoneNumberTypeFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeListResponse>> Get()
        {
            var response = await _phoneNumberTypeFacade.FindAllAsync();

            return Response(response);
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumberTypeResponse>> Get(int id)
        {
            var phoneNumberType = await _phoneNumberTypeFacade.Get(id);

            return Response(phoneNumberType);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] PhoneNumberTypeDto phoneNumberTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = await _phoneNumberTypeFacade.Insert(phoneNumberTypeDto);

            return Response(id, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PhoneNumberTypeDto phoneNumberTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _phoneNumberTypeFacade.Update(id, phoneNumberTypeDto);

            return Response(new PhoneNumberTypeResponse());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _phoneNumberTypeFacade.Delete(id);

            return Response(new PhoneNumberTypeResponse());
        }
    }
}
