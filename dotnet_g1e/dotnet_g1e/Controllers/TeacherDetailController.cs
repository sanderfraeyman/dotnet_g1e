using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g1e.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g1e.Controllers
{
    //[Authorize(Policy = "AdminOnly")]
    public class TeacherDetailController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        public TeacherDetailController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public IActionResult Index(int id)
        {
            Session session = _sessionRepository.GetBy(id);
            if (session == null)
                return NotFound();
            return View(session);
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
    }
}