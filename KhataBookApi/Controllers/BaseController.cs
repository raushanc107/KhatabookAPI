using System.Security.Claims;
using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KhataBookApi.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        protected Users _user;
        protected readonly ApplicationDbContext _context;
        public BaseController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var identity = HttpContext?.User?.Identity as ClaimsIdentity;
            if (identity != null && identity.IsAuthenticated)
            {
                var emailClaim = identity.FindFirst(ClaimTypes.Email)?.Value;
                if (emailClaim != null)
                {
                    _user = _context.Users.Where(E => E.email == emailClaim).FirstOrDefault();
                }
            }
        }

    }
}
