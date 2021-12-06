using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PhoneNumberTypeAggregate
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;

        }

        public async Task<List<PhoneNumberType>> FindAllAsync() => (await _phoneNumberTypeRepository.FindAllAsync()).ToList();

        public async Task<PhoneNumberType> Get(int id)
        {
            return await _phoneNumberTypeRepository.Get(id);
        }

        public async Task<int> Insert(PhoneNumberType phoneNumberType)
        {
            return await _phoneNumberTypeRepository.Insert(phoneNumberType);
        }

        public async Task Update(int id, PhoneNumberType phoneNumberType)
        {
            await _phoneNumberTypeRepository.Update(id, phoneNumberType);
        }

        public async Task Delete(int id)
        {
            await _phoneNumberTypeRepository.Delete(id);
        }
    }
}
