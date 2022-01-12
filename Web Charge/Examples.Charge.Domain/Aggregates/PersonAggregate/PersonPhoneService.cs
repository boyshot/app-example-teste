using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<IEnumerable<PersonPhone>> Get(Expression<Func<PersonPhone, bool>> filter)
        {
            return await _personPhoneRepository.Get(filter);
        }

        public async Task<PersonPhone> Insert(PersonPhone personPhone)
        {
           return await _personPhoneRepository.Insert(personPhone);
        }

        public async Task<PersonPhone> Update(PersonPhone personPhone, PersonPhone beforePersonPhoneRequest)
        {
            return await _personPhoneRepository.Update(personPhone, beforePersonPhoneRequest);
        }

        public async Task<bool> Delete(PersonPhone personPhone) => await _personPhoneRepository.Delete(personPhone);
  
    }
}
