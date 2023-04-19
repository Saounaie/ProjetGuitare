using JOUJE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jouje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VibratoController : ControllerBase
    {
        Base _base;

        public VibratoController(Base @base)
        {
            _base = @base;
        }

        [HttpGet("GetAllVibratos", Name = "GetAllVibratos")]
        public ActionResult<List<Vibrato>> GetAllVibratos()
        {
            try
            {
                return Ok(_base.GetAllVibratos().ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*[HttpGet("GetGuitareById", Name = "GetBoisById")]
        public ActionResult<Bois> GetBoisById(int _id)
        {
            try
            {
                return Ok(_base.GetBoisById(_id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        [HttpPost("AddVibrato", Name = "AddVibrato")]
        public ActionResult<Vibrato> AddVibrato([FromBody] Vibrato _vibrato)
        {
            try
            {
                _base.AddVibrato(ref _vibrato);
                return Ok(_vibrato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpPut("UpdateVibrato", Name = "UpdateVibrato")]
        public ActionResult<Vibrato> UpdateVibrato([FromBody] Vibrato _vibrato)
        {
            try
            {
                _base.UpdateVibrato(ref _vibrato);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteVibrato", Name = "DeleteVibrato")]
        public ActionResult DeleteVibrato(int _id)
        {
            try
            {

                _base.DeleteVibrato(_id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
