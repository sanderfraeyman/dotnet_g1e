using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g1e.Controllers
{
    [Authorize(Policy = "TeacherOnly")]
    public class TeacherDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}