using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g1e.Models;
using dotnet_g1e.Data;
using dotnet_g1e.Data.Repositories;

namespace dotnet_g1e.Controllers
{
    public class HomeController : Controller
    {
        private readonly SessionRepository _sessionRepository;
        public HomeController(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public IActionResult Index()
        {
            
            return View(_sessionRepository.GetAll().OrderBy(s => s.Name).ToList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}