﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekt.Areas.Identity.Data;

namespace Projekt.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ProjektUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<ProjektUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Egy felhasználó kilépett");
            //Projekt.Controllers.HomeController.bejelentkezve = false;
            //if (returnUrl != null)
            //{
            //    return LocalRedirect(returnUrl);
            //}
            //else
            //{
            //    return LocalRedirect("/Home/Index");
            //}
            return LocalRedirect("/Home/Index");
        }
    }
}
