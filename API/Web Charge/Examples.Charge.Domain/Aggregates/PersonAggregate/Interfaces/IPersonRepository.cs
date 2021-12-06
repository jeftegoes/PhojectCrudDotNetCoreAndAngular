using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAllAsync();
        Task<Person> Get(int id);
        Task<int> Insert(Person person);
        Task Update(int id, Person person);
        Task Delete(int id);
    }
}
