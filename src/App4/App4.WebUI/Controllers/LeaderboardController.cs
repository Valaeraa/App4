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
using App4.WebUI.ViewModels;

namespace App4.WebUI.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardEndpoint _leaderboardEndpoint;
        private readonly IUsersEndpoint _usersEndpoint;

        public LeaderboardController(ILeaderboardEndpoint leaderboardEndpoint, IUsersEndpoint usersEndpoint)
        {
            _leaderboardEndpoint = leaderboardEndpoint;
            _usersEndpoint = usersEndpoint;
        }

        // GET: Leaderboard
        public async Task<IActionResult> Index()
        {
            var leaderboards = await _leaderboardEndpoint.GetAll();

            return View(leaderboards.ToList());
        }

        // GET: Leaderboard/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderboard = await _leaderboardEndpoint.GetById(id.Value);

            if (leaderboard == null)
            {
                return NotFound();
            }

            return View(leaderboard);
        }

        // GET: Leaderboard/Create
        public async Task<IActionResult> Create()
        {
            var leaderboardVM = new LeaderboardViewModel();
            leaderboardVM.Users = await _usersEndpoint.GetAll();
            leaderboardVM.Users.ToList();

            return View(leaderboardVM);
        }

        // POST: Leaderboard/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Score,GamesPlayed")] LeaderboardModel leaderboard)
        {
            if (ModelState.IsValid)
            {
                await _leaderboardEndpoint.Create(leaderboard);

                return RedirectToAction(nameof(Index));
            }
            return View(leaderboard);
        }

        // GET: Leaderboard/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderboard = await _leaderboardEndpoint.GetById(id.Value);
            
            if (leaderboard == null)
            {
                return NotFound();
            }
            return View(leaderboard);
        }

        // POST: Leaderboard/Edit/1
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Score,GamesPlayed")] LeaderboardModel leaderboard)
        {
            if (id != leaderboard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaderboardEndpoint.Update(id, leaderboard);
                }
                catch (Exception ex)
                {
                    if (await LeaderboardExists(leaderboard.Id) == false)
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
            return View(leaderboard);
        }

        private async Task<bool> LeaderboardExists(int id)
        {
            var leaderboards = await _leaderboardEndpoint.GetAll();

            return leaderboards.Any(e => e.Id == id);
        }
    }
}
