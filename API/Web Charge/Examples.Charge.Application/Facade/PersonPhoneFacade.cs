using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService PersonPhoneService, IMapper mapper)
        {
            _personPhoneService = PersonPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            
            var response = new PersonPhoneListResponse();
            
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));

            return response;
        }

        public async Task<PersonPhoneResponse> Get(int businessEntityID, string phoneNumber, int phoneNumberTypeID)
        {
            var personPhone = await _personPhoneService.Get(businessEntityID, phoneNumber, phoneNumberTypeID);

            var personPhoneResponse = _mapper.Map<PersonPhone, PersonPhoneResponse>(personPhone);

            return personPhoneResponse;
        }

        public async Task<int> Insert(PersonPhoneDto personPhoneDto)
        {
            var personPhone = _mapper.Map<PersonPhoneDto, PersonPhone>(personPhoneDto);

            return await _personPhoneService.Insert(personPhone);
        }

        public async Task Update(PersonPhoneDto personPhoneDtoOld, PersonPhoneDto personPhoneDtoNew)
        {
            var personPhoneOld = _mapper.Map<PersonPhoneDto, PersonPhone>(personPhoneDtoOld);
            var personPhoneNew = _mapper.Map<PersonPhoneDto, PersonPhone>(personPhoneDtoNew);

            await _personPhoneService.Update(personPhoneOld, personPhoneNew);
        }

        public async Task Delete(PersonPhoneDto personPhoneDto)
        {
            var personPhone = _mapper.Map<PersonPhoneDto, PersonPhone>(personPhoneDto);

            await _personPhoneService.Delete(personPhone);
        }
    }
}
