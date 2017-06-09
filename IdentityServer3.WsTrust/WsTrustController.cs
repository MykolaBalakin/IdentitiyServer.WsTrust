using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityServer3.WsTrust
{
    [RoutePrefix("")]
    public class WsTrustController : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok("It's working!");
        }
    }
}