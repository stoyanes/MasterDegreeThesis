using Server.Data.Model;
using System.Web.Http;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("VacationRequests")]
    public class VacationRequestController : BaseController<VacationRequest>
    {
    }
}
