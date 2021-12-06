using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeService
    {
        Task<List<PhoneNumberType>> FindAllAsync();
        Task<PhoneNumberType> Get(int id);
        Task<int> Insert(PhoneNumberType phoneNumberType);
        Task Update(int id, PhoneNumberType phoneNumberType);
        Task Delete(int id);
    }
}
