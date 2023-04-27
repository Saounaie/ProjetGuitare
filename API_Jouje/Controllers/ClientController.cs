using JOUJE_DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_Jouje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        Base _base;

        public ClientController(Base @base)
        {
            _base = @base;
        }

        [HttpPost("CreateClient", Name = "CreateClient")]
        public ActionResult<Client> CreateClient([FromBody] Client client)
        {
            _base.CreateClient(ref client);
            return Ok(client);
        }

        [HttpPut("UpdateClient", Name = "UpdateClient")]
        public ActionResult<Client> UpdateClient(Client client)
        {
            _base.UpdateClient(ref client);
            return Ok(client);
        }

        [HttpPost("VerifyLogin", Name = "VerifyLogin")]
        public async Task<bool> VerifyLogin(Client client)
        {
            if (await _base.VerifyLogin(client))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("GetClientByID/{clientID}", Name = "GetClientByID")]
        public async Task<Client> GetClientByID(int clientID)
        {
            var client = new Client { idClient= clientID };
            return await _base.GetClientByID(client);
        }

       /* [HttpPost("VerifyLoginWithID", Name = "VerifyLoginWithID")]
        public async Task<bool> VerifyLoginWithID(Client client)
        {
            var (success, clientId) = await _base.VerifyLoginWithID(client);

            if (success)
            {
                client.idClient = clientId;
                return true;
            }
            else
            {
                return false;
            }
        }*/

        [HttpPost("GetIDByClient", Name = "GetIDByClient")]
        public async Task<int> GetIDByClient([FromBody] Client client)
        {
            return await _base.GetIDByClient(client);
        }

    }
}
