﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g1e.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}