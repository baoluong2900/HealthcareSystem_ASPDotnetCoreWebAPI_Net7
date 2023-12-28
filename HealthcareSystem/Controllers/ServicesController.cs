using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Models;
using HealthcareSystem.ModelViews;
using HealthcareSystem.Extensions;
using static HealthcareSystem.ModelViews.ServiceView;
using System.Collections;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly DbHealthcareSystemContext _context;

        public ServicesController(DbHealthcareSystemContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            if (_context.Services == null)
            {
                return NotFound();
            }
            return await _context.Services.ToListAsync();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            if (_context.Services == null)
            {
                return NotFound();
            }
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpGet("staff/{staffId}")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServicesByStaffId(int staffId)
        {
            if (_context.Services == null)
            {
                return NotFound();
            }

            return await _context.Services.AsNoTracking().Where(u => u.StaffId == staffId).ToListAsync();
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, ServiceRequest serviceRequest)
        {

            var service = await _context.Services.FirstOrDefaultAsync(u => u.ServiceId == id);
            try
            {
                if (service != null)
                {
                    Extenions.CopyObjectData(serviceRequest, service);
                    service.ModifiedDate = DateTime.Now;
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(ServiceRequest serviceView)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'DbHealthcareSystemContext.Services'  is null.");
            }
            var service = new Service();
            Extenions.CopyObjectData(serviceView, service);
            service.CreateDate = DateTime.Now;
            service.ModifiedDate = null;
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetService", new { id = service.ServiceId }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteService(int id)
        {
            if (_context.Services == null)
            {
                return false;
            }
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return false;
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ServiceExists(int id)
        {
            return (_context.Services?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
