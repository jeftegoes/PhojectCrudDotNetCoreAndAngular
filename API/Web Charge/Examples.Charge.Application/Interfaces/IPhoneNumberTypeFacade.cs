using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneNumberTypeFacade
    {
        Task<PhoneNumberTypeListResponse> FindAllAsync();
        Task<PhoneNumberTypeResponse> Get(int id);
        Task<int> Insert(PhoneNumberTypeDto personDto);
        Task Update(int id, PhoneNumberTypeDto personDto);
        Task Delete(int id);
    }
}