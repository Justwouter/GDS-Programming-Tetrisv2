using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Model;

namespace API.Controllers {
    [Route("api/")]
    [ApiController]
    public class ScoreController : ControllerBase {
        private readonly ScoreContext _context;

        public ScoreController(ScoreContext context) {
            _context = context;
        }

        [HttpGet("Score/GetScores")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores() {
            if (_context.Scores == null) {
                return NotFound();
            }
            return await _context.Scores.ToListAsync();
        }

        [HttpGet("Score/GetScore/{id}")]
        public async Task<ActionResult<Score>> GetScore(int id) {
            if (_context.Scores == null) {
                return NotFound();
            }
            var score = await _context.Scores.FindAsync(id);

            if (score == null) {
                return NotFound();
            }

            return score;
        }

        [HttpPost("Score/NewScore")]
        public async Task<ActionResult<Score>> PostScore(Score score) {
            if (_context.Scores == null) {
                return Problem("Entity set 'ScoreContext.Scores'  is null.");
            }
            if (score.Highscore < 99) {
                _context.Scores.Add(score);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetScore", new { id = score.Id }, score);
            }
            return Problem(">100 is not possible. Please contact admins if you think it is.");

        }

        [HttpPost("Score/NewScoreForm")]
        public async Task<ActionResult<Score>> PostScoreForm([FromForm] Score score) {
            Console.WriteLine(score.Highscore);
            if (_context.Scores == null) {
                return Problem("Entity set 'ScoreContext.Scores'  is null.");
            }
            if (score.Highscore < 99) {
                _context.Scores.Add(score);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetScore", new { id = score.Id }, score);
            }
            return Problem(">100 is not possible. Please contact admins if you think it is.");
        }

        [HttpDelete("Score/DeleteScore/{id}")]
        public async Task<IActionResult> DeleteScore(int id) {
            if (_context.Scores == null) {
                return NotFound();
            }
            var score = await _context.Scores.FindAsync(id);
            if (score == null) {
                return NotFound();
            }

            _context.Scores.Remove(score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Score/DeleteScoreRange/{to}-{from}")]
        public async Task<IActionResult> DeleteRange(int to, int from) {
            for (int i = from; i < to; i++) {
                var score = await _context.Scores.FindAsync(i);
                if (score != null) {
                    _context.Scores.Remove(score);
                }
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }




        [HttpGet("ScoreBoard/GetScoreBoard")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScoreBoard() {
            if (_context.Scores == null) {
                return NotFound();
            }
            var allScores = await _context.Scores.ToListAsync();
            return allScores.OrderBy(e => e.Highscore).Take(10).ToList();
        }

        [HttpGet("ScoreBoard/GetScoreBoardEntry/{id}")]
        public async Task<ActionResult<Score>> GetScoreBoardEntry(int id) {
            if (_context.Scores == null) {
                return NotFound();
            }
            var allScores = await _context.Scores.ToListAsync();
            return allScores.OrderBy(e => e.Highscore).Reverse().Take(10).ToArray()[id];
        }

        private bool ScoreExists(int id) {
            return (_context.Scores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
