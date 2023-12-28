using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Models;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSchedulesController : ControllerBase
    {
        private readonly DbHealthcareSystemContext _context;

        public WorkSchedulesController(DbHealthcareSystemContext context)
        {
            _context = context;
        }

        // GET: api/WorkSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkSchedule>>> GetWorkSchedules()
        {
            if (_context.WorkSchedules == null)
            {
                return NotFound();
            }
            return await _context.WorkSchedules.ToListAsync();
        }

        // GET: api/WorkSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkSchedule>> GetWorkSchedule(int id)
        {
            if (_context.WorkSchedules == null)
            {
                return NotFound();
            }
            var workSchedule = await _context.WorkSchedules.FindAsync(id);

            if (workSchedule == null)
            {
                return NotFound();
            }

            return workSchedule;
        }

        // PUT: api/WorkSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkSchedule(int id, WorkSchedule workSchedule)
        {
            if (id != workSchedule.WorkScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(workSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkScheduleExists(id))
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

        // POST: api/WorkSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkSchedule>> PostWorkSchedule(WorkSchedule workSchedule)
        {
            if (_context.WorkSchedules == null)
            {
                return Problem("Entity set 'DbHealthcareSystemContext.WorkSchedules'  is null.");
            }
            _context.WorkSchedules.Add(workSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkSchedule", new { id = workSchedule.WorkScheduleId }, workSchedule);
        }

        // DELETE: api/WorkSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkSchedule(int id)
        {
            if (_context.WorkSchedules == null)
            {
                return NotFound();
            }
            var workSchedule = await _context.WorkSchedules.FindAsync(id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            _context.WorkSchedules.Remove(workSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkScheduleExists(int id)
        {
            return (_context.WorkSchedules?.Any(e => e.WorkScheduleId == id)).GetValueOrDefault();
        }
    }
}
