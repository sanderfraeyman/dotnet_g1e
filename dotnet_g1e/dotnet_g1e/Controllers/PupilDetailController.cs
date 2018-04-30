using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g1e.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g1e.Controllers
{
    public class PupilDetailController : Controller
    {
        private readonly ISessionRepository _sessionRepository;

        public PupilDetailController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public IActionResult Index(int id)
        {
            Session session = _sessionRepository.GetBy(id);

            ViewData["playgroups"] = _sessionRepository.GetPlaygroupsFromSession(id);
            ViewData["pupils"] = _sessionRepository.GetPlaygroupsFromSession(id).SelectMany(s => s.PlayGroupPupils).Select(pp => pp.Pupil).ToList();

            if (session == null)
            {
                return NotFound();
            }
            else
            {
                return View(session);
            }
        }
        
        public IActionResult Join(int id)
        {
            Session session = _sessionRepository.GetBy(id);
            if (session == null)
                return NotFound();
            ViewData[nameof(Session.Name)] = session.Name;
            return View();
        }
        
        [HttpPost, ActionName("Join")]
        public IActionResult JoinConfirmed(int id)
        {
            Session session = null;
            try
            {
                session = _sessionRepository.GetBy(id);
                //set group as checked in
                _sessionRepository.SaveChanges();
                TempData["message"] = $"You successfully joined {session.Name}.";
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong, session {session?.Name} was not activated…";
            }
            //sends the group to the waiting screen
            return RedirectToAction("Play", "Index");
        }
    }
}