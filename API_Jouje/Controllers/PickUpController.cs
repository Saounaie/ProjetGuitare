using JOUJE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jouje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickUpController : ControllerBase
    {
        Base _base;
        public PickUpController(Base laBase)
        {
            _base = laBase;
        }

        [HttpGet("GetAllMicros", Name = "GetAllMicros")]
        public ActionResult<List<PickUp>> GetAllMicros()
        {
            try
            {
                return Ok(_base.GetAllMicros().ToList());
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

        [HttpPost("AddMicro", Name = "AddMicro")]
        public ActionResult<PickUp> AddMicro([FromBody] PickUp _micro)
        {
            try
            {
                _base.AddMicro(ref _micro);
                return Ok(_micro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        [HttpPut("UpdateMicro", Name = "UpdateMicro")]
        public ActionResult<PickUp> UpdateMicro([FromBody] PickUp _micro)
        {
            try
            {
                _base.UpdateMicro(ref _micro);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteMicro", Name = "DeleteMicro")]
        public ActionResult DeleteMicro(int _id)
        {
            try
            {

                _base.DeleteMicro(_id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
