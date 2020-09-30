using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monafasati.Data;
using Monafasati.Data.ModelDto;

namespace Monafasati.Web.Controllers.UserAdmin
{
    public class AdminController : Controller
    {
        private readonly MonafasatiDbContext context;

        public AdminController(MonafasatiDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var UserList = context.Users.ToList();
            return View(UserList);
        }
    }
}
