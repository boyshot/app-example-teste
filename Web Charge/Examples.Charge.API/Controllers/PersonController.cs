using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonFacade personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            this.personFacade = personFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await personFacade.FindAllAsync());


        [HttpGet("{id:int}/person-phone")]
        public async Task<PersonPhoneResponse> GetPersonPhone(int id)
        {
            var personResponse = await personFacade.GetPersonPhoneByIdPerson(id);

            return personResponse;
        }

        [HttpPost("add-person-phone")]
        public async Task<IActionResult> InsertPersonPhone(PersonPhoneRequest request)
        {
            var result = await personFacade.InsertPersonPhone(request);

            return Response(0, result);
        }

        [HttpPut("update-person-phone")]
        public async Task<IActionResult> UpdatePersonPhone(PersonPhoneRequest request)
        {
            var result = await personFacade.UpdatePersonPhone(request);

            return Response(null, result);
        }

        [HttpDelete("delete-person-phone")]
        public async Task<IActionResult> DeletePersonPhone(PersonPhoneRequest request)
        {
            await personFacade.DeletePersonPhone(request);

            return Response(null, null);
        }

        [HttpGet("list-phone-number-type")]
        public async Task<ActionResult<PhoneNumberTypeResponse>> PhoneNumberType() => Response(await personFacade.GetListPhoneNumberType());
    }
}
