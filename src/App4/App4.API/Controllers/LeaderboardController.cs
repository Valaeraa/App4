using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App4.Data;
using App4.Data.Models;

namespace App4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly App4Context _context;

        public LeaderboardController(App4Context context)
        {
            _context = context;
        }

        // GET: api/Leaderboard
        /// <summary>
        /// Returns all the leaderboards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leaderboard>>> GetLeaderboards()
        {
            return await _context.Leaderboards.ToListAsync();
        }

        // GET: api/Leaderboard/1
        /// <summary>
        /// Returns the leaderboard
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Leaderboard>> GetLeaderboard(int id)
        {
            var leaderboard = await _context.Leaderboards.FindAsync(id);

            if (leaderboard == null)
            {
                return NotFound();
            }

            return leaderboard;
        }

        // PUT: api/Leaderboard/1
        /// <summary>
        /// Update a users entry to the leaderboard
        /// </summary>
        /// <param name="id"></param>
        /// <param name="leaderboard"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaderboard(int id, Leaderboard leaderboard)
        {
            if (id != leaderboard.Id)
            {
                return BadRequest();
            }

            _context.Entry(leaderboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaderboardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Leaderboard
        /// <summary>
        /// Create a users entry to the leaderboard
        /// </summary>
        /// <param name="leaderboard"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Leaderboard>> CreateLeaderboard(Leaderboard leaderboard)
        {
            _context.Leaderboards.Add(leaderboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaderboard", new { id = leaderboard.Id }, leaderboard);
        }

        private bool LeaderboardExists(int id)
        {
            return _context.Leaderboards.Any(e => e.Id == id);
        }
    }
}
