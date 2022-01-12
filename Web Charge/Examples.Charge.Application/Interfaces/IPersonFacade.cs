using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonPhoneResponse> GetPersonPhoneByIdPerson(int idPerson);
        Task<PersonPhoneResponse> InsertPersonPhone(PersonPhoneRequest personPhoneRequest);
        Task<PersonPhoneResponse> UpdatePersonPhone(PersonPhoneRequest personPhoneRequest);
        Task<bool> DeletePersonPhone(PersonPhoneRequest request);
        Task<PhoneNumberTypeResponse> GetListPhoneNumberType();
    }
}