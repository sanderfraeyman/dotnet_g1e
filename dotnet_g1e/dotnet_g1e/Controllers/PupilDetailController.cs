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
            if (session == null)
            {
                return NotFound();
            }
            else
            {
                return View(session);
            }
        }
    }
}