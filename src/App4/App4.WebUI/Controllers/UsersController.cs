using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App4.Data;
using App4.Data.Entities;
using App4.WebUI.Api;
using App4.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace App4.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersEndpoint _usersEndpoint;

        public UsersController(IUsersEndpoint usersEndpoint)
        {
            _usersEndpoint = usersEndpoint;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _usersEndpoint.GetAll();

            return View(users.ToList());
        }

        // GET: Users/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _usersEndpoint.GetById(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Telephone")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                await _usersEndpoint.Create(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _usersEndpoint.GetById(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Edit/1
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Telephone")] UserModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _usersEndpoint.Update(id, user);
                }
                catch (Exception ex)
                {
                    if (await UserExists(user.Id) == false)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private async Task<bool> UserExists(int id)
        {
            var users = await _usersEndpoint.GetAll();

            return users.Any(e => e.Id == id);
        }
    }
}
