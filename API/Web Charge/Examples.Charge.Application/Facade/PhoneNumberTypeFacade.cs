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
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }

        public async Task<PhoneNumberTypeListResponse> FindAllAsync()
        {
            var result = await _phoneNumberTypeService.FindAllAsync();
            
            var response = new PhoneNumberTypeListResponse();
            
            response.PhoneNumberTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));

            return response;
        }

        public async Task<PhoneNumberTypeResponse> Get(int id)
        {
            var phoneNumberType = await _phoneNumberTypeService.Get(id);

            var PhoneNumberTypeResponse = _mapper.Map<PhoneNumberType, PhoneNumberTypeResponse>(phoneNumberType);

            return PhoneNumberTypeResponse;
        }

        public async Task<int> Insert(PhoneNumberTypeDto PhoneNumberTypeDto)
        {
            var PhoneNumberType = _mapper.Map<PhoneNumberTypeDto, PhoneNumberType>(PhoneNumberTypeDto);

            return await _phoneNumberTypeService.Insert(PhoneNumberType);
        }

        public async Task Update(int id, PhoneNumberTypeDto PhoneNumberTypeDto)
        {
            var PhoneNumberType = _mapper.Map<PhoneNumberTypeDto, PhoneNumberType>(PhoneNumberTypeDto);

            await _phoneNumberTypeService.Update(id, PhoneNumberType);
        }

        public async Task Delete(int id)
        {
            await _phoneNumberTypeService.Delete(id);
        }
    }
}
