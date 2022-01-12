using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);


        public async Task<IEnumerable<PersonPhone>> Get(Expression<Func<PersonPhone, bool>> filter)
        {
            return await Task.Run(() => _context.PersonPhone
                                        .Where(filter)
                                        .Include(y => y.Person)
                                        .Include(y => y.PhoneNumberType)
                                        .ToList());
        }

        public async Task<PersonPhone> Insert(PersonPhone personPhone)
        {
            _context.PersonPhone.Add(personPhone);
            await _context.SaveChangesAsync();

            var item = Get(y => y.PhoneNumber == personPhone.PhoneNumber &&
                           y.PhoneNumberTypeID == personPhone.PhoneNumberTypeID &&
                           y.BusinessEntityID == personPhone.BusinessEntityID).Result;

            return item.FirstOrDefault();
        }

        public async Task<bool> Delete(PersonPhone personPhone)
        {
            _context.PersonPhone.Remove(personPhone);

            int countDelete = await _context.SaveChangesAsync();

            return countDelete > 0;
        }

        public async Task<PersonPhone> Update(PersonPhone personPhone, PersonPhone beforePersonPhoneRequest)
        {

            bool deleteOk = await Delete(beforePersonPhoneRequest);

            if (deleteOk)
                await Insert(personPhone);

            await _context.SaveChangesAsync();

            var item = Get(y => y.PhoneNumber == personPhone.PhoneNumber &&
               y.PhoneNumberTypeID == personPhone.PhoneNumberTypeID &&
               y.BusinessEntityID == personPhone.BusinessEntityID).Result;

            return item.FirstOrDefault();
        }
    }
}
