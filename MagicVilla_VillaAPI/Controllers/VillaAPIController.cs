using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok (VillaStore.villaList);
        }
        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(200, Type=typeof(VillaDTO))]

        public ActionResult GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var Villa = VillaStore.villaList.FirstOrDefault(u => u.id == id);
            if (Villa==null)
            {
                return NotFound();
            }
            return Ok(Villa);
        }
    }
}
