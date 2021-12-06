using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonResponse> Get(int id);
        Task<int> Insert(PersonDto personDto);
        Task Update(int id, PersonDto personDto);
        Task Delete(int id);
    }
}