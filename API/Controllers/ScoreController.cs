using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Model;

namespace API.Controllers
{
    [Route("api/ScoreBoard")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ScoreContext _context;

        public ScoreController(ScoreContext context)
        {
            _context = context;
        }

        // GET: api/Score
        [HttpGet("GetScores")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
          if (_context.Scores == null)
          {
              return NotFound();
          }
            return await _context.Scores.ToListAsync();
        }

        [HttpGet("GetScoreBoard")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScoreBoard()
        {
          if (_context.Scores == null)
          {
              return NotFound();
          }
            var allScores = await _context.Scores.ToListAsync();
            return allScores.OrderBy(e => e.Highscore).Take(10).ToList();
        }

        // GET: api/Score/5
        [HttpGet("GetScore/{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
          if (_context.Scores == null)
          {
              return NotFound();
          }
            var score = await _context.Scores.FindAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        // POST: api/Score
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("NewScore")]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
          if (_context.Scores == null)
          {
              return Problem("Entity set 'ScoreContext.Scores'  is null.");
          }
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.Id }, score);
        }

        private bool ScoreExists(int id)
        {
            return (_context.Scores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
