using JOUJE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jouje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitareController : ControllerBase
    {
        Base _base;

        public GuitareController(Base @base)
        {
            _base = @base;
        }

        [HttpGet("GetAllGuitares", Name = "GetAllGuitares")]
        public ActionResult<List<Guitare>> GetAllGuitares()
        {
            return Ok(_base.GetAllGuitares());
        }

        [HttpGet("GetGuitareByID", Name = "GetGuitareByID")]
        public ActionResult<Guitare> GetGuitareByID(int id)
        {
            var guitare = _base.GetGuitareById(id);
            return Ok(guitare);
        }

        [HttpPost("AddGuitare", Name = "AddGuitare")]
        public ActionResult<Guitare> AddGuitare([FromBody] Guitare guitare)
        {

            _base.AddGuitare(ref guitare);
            return Ok(guitare);
        }

        [HttpPut("UpdateGuitare", Name = "UpdateGuitare")]
        public ActionResult<Guitare> UpdateGuitare([FromBody] Guitare _guitare)
        {
            _base.UpdateGuitare(ref _guitare);
            return Ok(_guitare);
        }

        [HttpDelete("DeletGuitare", Name = "DeletGuitare")]
        public ActionResult<Guitare> DeletGuitare(int id)
        {
            _base.DeleteGuitare(id);
            return Ok();
        }
    }
}
