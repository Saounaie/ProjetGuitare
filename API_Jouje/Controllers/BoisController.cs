using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JOUJE_DLL;

namespace API_Jouje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoisController : ControllerBase
    {
        Base _base;

        public BoisController(Base @base)
        {
            _base = @base;  
        }

        [HttpGet("GetAllBois", Name = "GetAllBois")]
        public ActionResult<List<Bois>> GetAllBois()
        {
            try
            {
                return Ok(_base.GetAllBois().ToList());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetBoisById", Name ="GetBoisById")]
        public ActionResult<Bois> GetBoisById(int _id)
        {
            try
            {
                return Ok(_base.GetBoisById(_id));
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AddBois", Name = "AddBois")]
        public ActionResult<Bois> AddBois([FromBody] Bois _bois)
        {
            try
            {
                _base.AddBois(ref _bois);
                return Ok(_bois);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateBoisObj", Name = "UpdateBoisObj")]
        public ActionResult<Bois> UpdateBoisObj([FromBody] Bois _bois)
        {
            try
            {
                _base.UpdateBois(ref _bois);
                return Ok(_bois);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateBois", Name = "UpdateBois")]
        public ActionResult<Bois> UpdateBois(int idBois, string nomBois, double poidsBois, string region)
        {
            try
            {
                _base.UpdateBois(idBois, nomBois, poidsBois, region);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteBois", Name = "DeleteBois")]
        public ActionResult DeleteBois(int _id)
        {
            try
            {

                _base.DeleteBois(_id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
