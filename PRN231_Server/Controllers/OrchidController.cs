using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Impl;
using Service.Model.Request;

namespace PRN231_Server.Controllers
{
    [ApiController]
    [Route("api/orchids")]
    public class OrchidController : Controller
    {
        private IOrchidService orchidService;
        public OrchidController(IOrchidService orchidService)
        {
            this.orchidService = orchidService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = orchidService.GetAll();
            if (list == null)
            {
                return NotFound("There is no orchids!");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpGet("{id}/getId")]
        public IActionResult GetById(Guid id)
        {
            var orchid = orchidService.GetOrchidById(id);
            if (orchid == null)
            {
                return NotFound("There is no orchid with this id: " + id);
            }
            return Ok(orchid);
        }

        [HttpGet("{name}/getName")]
        public IActionResult GetByName(string name)
        {
            var orchid = orchidService.GetOrchidByName(name);
            if (orchid == null)
            {
                return NotFound("There is no orchid with this name: " + name);
            }
            return Ok(orchid);
        }


        [HttpPost]
        public IActionResult AddOrchid([FromBody] OrchidRequestDto orchidRequestDto)
        {
            if (orchidRequestDto != null)
            {
                var orchid = orchidService.AddOrchid(orchidRequestDto);
                return new CreatedAtActionResult(nameof(AddOrchid), "Orchid", new { Name = orchid.Name }, orchid);
            }
            else
            {
                return BadRequest("Add orchid fail!!");
            }
        }


        [HttpPut]
        public IActionResult EditOrchid([FromBody] EditOrchidDto editOrchidDto)
        {
            if (editOrchidDto != null)
            {
                var orchid = orchidService.UpdateOrchid(editOrchidDto);
                if (orchid == null)
                {
                    return BadRequest("Edit orchid fail!!");
                }
                return Ok(orchid);
            }
            else
            {
                return BadRequest("Edit orchid fail!!");
            }
        }

        [HttpDelete]
        public IActionResult RemoveOrchid(Guid id)
        {
            if (id != null)
            {
                orchidService.RemoveOrchid(id);
                return Ok("Delete orchid success !!");
            }
            else
            {
                return BadRequest("Remove orchid fail!!");
            }
        }

    }
}
