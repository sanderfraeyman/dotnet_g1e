using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g1e.Models;
using dotnet_g1e.Data;
using dotnet_g1e.Data.Repositories;
using dotnet_g1e.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_g1e.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        public HomeController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public IActionResult Index()
        {
            
            return View(_sessionRepository.GetAll().ToList());
        }

        //[Authorize(Policy = "AdminOnly")]
        public IActionResult Activate(int id)
        {
            Session session = _sessionRepository.GetBy(id);
            if (session == null)
                return NotFound();
            ViewData[nameof(Session.Name)] = session.Name;
            return View();
        }

        //[Authorize(Policy = "AdminOnly")]
        [HttpPost, ActionName("Activate")]
        public IActionResult ActivateConfirmed(int id)
        {
            Session session = null;
            try
            {
                session = _sessionRepository.GetBy(id);
                session.ActiveSession = true;
                _sessionRepository.SaveChanges();
                TempData["message"] = $"You successfully activated {session.Name}.";
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong, session {session?.Name} was not activated…";
            }
            return RedirectToAction(nameof(Index));
        }

        //[Authorize(Policy = "AdminOnly")]
        public IActionResult Deactivate(int id)
        {
            Session session = _sessionRepository.GetBy(id);
            if (session == null)
                return NotFound();
            ViewData[nameof(Session.Name)] = session.Name;
            return View();
        }

        //[Authorize(Policy = "AdminOnly")]
        [HttpPost, ActionName("Deactivate")]
        public IActionResult DeactivateConfirmed(int id)
        {
            Session session = null;
            try
            {
                session = _sessionRepository.GetBy(id);
                session.ActiveSession = false;
                _sessionRepository.SaveChanges();
                TempData["message"] = $"You successfully deactivated {session.Name}.";
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong, session {session?.Name} was not deactivated…";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}