using Microsoft.AspNetCore.Mvc;
using TABv3.Entities;

namespace TABv3.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
