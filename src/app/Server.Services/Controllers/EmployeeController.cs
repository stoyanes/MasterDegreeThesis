using System.Web.Http;
using Server.Data.Model;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("Employees")]
    public class EmployeeController : BaseController<Employee>
    { 
    }
}
