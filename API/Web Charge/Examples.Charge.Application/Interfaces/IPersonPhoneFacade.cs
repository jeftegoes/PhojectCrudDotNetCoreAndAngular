using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindAllAsync();
        Task<PersonPhoneResponse> Get(int businessEntityID, string phoneNumber, int phoneNumberTypeID);
        Task<int> Insert(PersonPhoneDto personDto);
        Task Update(PersonPhoneDto personPhoneDtoOld, PersonPhoneDto personPhoneDtoNew);
        Task Delete(PersonPhoneDto personDto);
    }
}