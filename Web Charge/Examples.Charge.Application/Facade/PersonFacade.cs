using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;

        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService,
                            IPersonPhoneService personPhoneService,
                            IPhoneNumberTypeService phoneNumberTypeService,
                            IMapper mapper)
        {
            _personService = personService;
            _personPhoneService = personPhoneService;
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonPhoneResponse> GetPersonPhoneByIdPerson(int idPerson)
        {
            var response = new PersonPhoneResponse();

            var result = await _personPhoneService.Get(y => y.Person.BusinessEntityID == idPerson);

            if (result == null) return response;

            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));

            return response;
        }

        public async Task<PersonPhoneResponse> InsertPersonPhone(PersonPhoneRequest personPhoneRequest)
        {
           var result = await _personPhoneService.Insert(_mapper.Map<PersonPhone>(personPhoneRequest));

            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));

            return response;
        }

        public async Task<PersonPhoneResponse> UpdatePersonPhone(PersonPhoneRequest personPhoneRequest)
        {
            var beforePersonPhoneRequest = _mapper.Map<PersonPhone>(personPhoneRequest.BeforePersonPhoneRequest);

            var result =  await _personPhoneService.Update(
                _mapper.Map<PersonPhone>(personPhoneRequest), beforePersonPhoneRequest);

            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects.Add(_mapper.Map<PersonPhoneDto>(result));

            return response;
        }

        public async Task<bool> DeletePersonPhone(PersonPhoneRequest personPhoneRequest)
        {
            return await _personPhoneService.Delete(_mapper.Map<PersonPhone>(personPhoneRequest));
        }

        public async Task<PhoneNumberTypeResponse> GetListPhoneNumberType()
        {
            var result = await _phoneNumberTypeService.FindAllAsync();
            var response = new PhoneNumberTypeResponse();
            response.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
            response.PhoneNumberTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));
            return response;
        }
    }
}
