using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<PersonPhone> Get(int businessEntityID, string phoneNumber, int phoneNumberTypeID);
        Task<int> Insert(PersonPhone personPhone);
        Task Update(PersonPhone personPhoneOld, PersonPhone personPhoneNew);
        Task Delete(PersonPhone personPhone);
    }
}
