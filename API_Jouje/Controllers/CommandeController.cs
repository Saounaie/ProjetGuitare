using JOUJE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jouje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        Base _base;

        public CommandeController(Base @base)
        {
            _base = @base;
        }

        [HttpGet("GetAllCommandes", Name = "GetAllCommandes")]
        public ActionResult<List<Commande>> GetAllCommandes()
        {
            return Ok(_base.GetAllCommandes());
        }
    }
}
