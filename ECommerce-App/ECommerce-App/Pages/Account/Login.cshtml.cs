﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerce_App.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.Persistent, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public class LoginViewModel
        {
            [Required]
            //[Display("Email Address")]
            [EmailAddress]
            public string Email { get; set; }

            // These are like server side versions of adding required and type="password" to the inputs on the front end
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool Persistent { get; set; }
        }
    }
}