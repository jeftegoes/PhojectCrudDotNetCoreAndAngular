using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeRepository
    {
        Task<IEnumerable<PhoneNumberType>> FindAllAsync();
        Task<PhoneNumberType> Get(int id);
        Task<int> Insert(PhoneNumberType phoneNumberType);
        Task Update(int id, PhoneNumberType phoneNumberType);
        Task Delete(int id);
    }
}
