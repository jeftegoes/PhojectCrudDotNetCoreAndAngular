using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonPhoneAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;

        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;

        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<PersonPhone> Get(int businessEntityID, string phoneNumber, int phoneNumberTypeID)
        {
            return await _personPhoneRepository.Get(businessEntityID, phoneNumber, phoneNumberTypeID);
        }

        public async Task<int> Insert(PersonPhone personPhone)
        {
            return await _personPhoneRepository.Insert(personPhone);
        }

        public async Task Update(PersonPhone personPhoneOld, PersonPhone personPhoneNew)
        {
            await _personPhoneRepository.Update(personPhoneOld, personPhoneNew);
        }

        public async Task Delete(PersonPhone personPhone)
        {
            await _personPhoneRepository.Delete(personPhone);
        }
    }
}