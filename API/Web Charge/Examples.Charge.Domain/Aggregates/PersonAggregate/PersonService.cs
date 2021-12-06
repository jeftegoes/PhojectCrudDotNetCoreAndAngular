using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> Get(int id)
        {
            return await _personRepository.Get(id);
        }

        public async Task<int> Insert(Person person)
        {
            return await _personRepository.Insert(person);
        }

        public async Task Update(int id, Person person)
        {
            await _personRepository.Update(id, person);
        }

        public async Task Delete(int id)
        {
            await _personRepository.Delete(id);
        }
    }
}
