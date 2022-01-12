using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<IEnumerable<PersonPhone>> Get(Expression<Func<PersonPhone, bool>> filter);
        Task<PersonPhone> Insert(PersonPhone personPhone);
        Task<bool> Delete(PersonPhone personPhone);
        Task<PersonPhone> Update(PersonPhone personPhone, PersonPhone beforePersonPhoneRequest);
    }
}
