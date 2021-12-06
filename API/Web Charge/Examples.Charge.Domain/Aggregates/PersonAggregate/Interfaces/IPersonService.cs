using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<Person> Get(int id);
        Task<int> Insert(Person person);
        Task Update(int id, Person person);
        Task Delete(int id);
    }
}
