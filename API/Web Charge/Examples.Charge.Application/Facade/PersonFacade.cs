using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            
            var response = new PersonListResponse();
            
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));

            return response;
        }

        public async Task<PersonResponse> Get(int id)
        {
            var person = await _personService.Get(id);

            var personResponse = _mapper.Map<Person, PersonResponse>(person);

            return personResponse;
        }

        public async Task<int> Insert(PersonDto personDto)
        {
            var person = _mapper.Map<PersonDto, Person>(personDto);

            return await _personService.Insert(person);
        }

        public async Task Update(int id, PersonDto personDto)
        {
            var person = _mapper.Map<PersonDto, Person>(personDto);

            await _personService.Update(id, person);
        }

        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }
    }
}
