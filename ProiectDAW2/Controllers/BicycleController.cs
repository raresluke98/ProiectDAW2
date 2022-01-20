using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectDAW2.Models;
using ProiectDAW2.Services;
using ProiectDAW2.ViewModels;

namespace ProiectDAW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly BicycleDbContext _context;

        public BicycleService _bicycleService;

        public BicycleController(BicycleDbContext context, BicycleService bicycleService)
        {
            _context = context;
            _bicycleService = bicycleService;
        }

        // GET: api/Bicycle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetBicycles()
        {
            return await _context.Bicycles.ToListAsync();
        }

        // GET: api/Bicycle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> GetBicycle(int id)
        {
            var bicycle = await _context.Bicycles.FindAsync(id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return bicycle;
        }

        // PUT: api/Bicycle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicycle(int id, Bicycle bicycle)
        {
            if (id != bicycle.BicycleId)
            {
                return BadRequest();
            }

            _context.Entry(bicycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycleExists(id))
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

        /*
        // POST: api/Bicycle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bicycle>> PostBicycle(Bicycle bicycle)
        {
            _context.Bicycles.Add(bicycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBicycle", new { id = bicycle.BicycleId }, bicycle);
        }
        */

        [HttpPost("add-bicycle")]
        public IActionResult AddBicycle([FromBody] BicycleVM bicycle)
        {
            _bicycleService.AddBicycle(bicycle);
            return Ok();
        }

        // DELETE: api/Bicycle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBicycle(int id)
        {
            var bicycle = await _context.Bicycles.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }

            _context.Bicycles.Remove(bicycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BicycleExists(int id)
        {
            return _context.Bicycles.Any(e => e.BicycleId == id);
        }
    }
}
