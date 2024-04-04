using FotovognRepositorylib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UdpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotovognsController : ControllerBase
    {
        // GET: FotovognsController
        private readonly IFotovognRepository _fotovognRepository;
        public FotovognsController(IFotovognRepository fotovognRepository)
        {
            _fotovognRepository = fotovognRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Fotovogn>> Get([FromQuery] string? nameFilter)
        {
            IEnumerable<Fotovogn> fotovogns   = _fotovognRepository.Get(null);
            if (nameFilter != null)
            {

                fotovogns = _fotovognRepository.Get(nameFilter);

            }
            if (fotovogns.Any())
            {
                
                return Ok(fotovogns);
            }


            else
            {
                return NoContent();
            }

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Fotovogn> Post([FromBody] Fotovogn fotovogn)
        {

                Fotovogn fotovogn1 = _fotovognRepository.AddFotovogn(fotovogn);
            
            return Created("/" + fotovogn1.Id, fotovogn1);

        }
        // POST: FotovognsController/Edit/5
       

        // GET: FotovognsController/Delete/5
       
    }
}
