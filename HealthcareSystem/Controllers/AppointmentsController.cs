using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Models;
using static HealthcareSystem.ModelViews.AppointmentView;
using HealthcareSystem.Extensions;
using HealthcareSystem.ModelViews;
using static HealthcareSystem.ModelViews.ServiceView;
using static HealthcareSystem.ModelViews.FarvoriteItem;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly DbHealthcareSystemContext _context;

        public AppointmentsController(DbHealthcareSystemContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet("user/{userID}")]
        public async Task<ActionResult<IEnumerable<FarvoriteItemReponse>>> GetAppointmentsByUserID(int userID)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }

            var listAppointments = await _context.Appointments
                .AsNoTracking()
                .Where(x => x.UserId == userID)
                .ToListAsync();

            var listServiceId = listAppointments.Select(x=>x.ServiceId).Distinct().ToList();
            var listService = await _context.Services
                .AsNoTracking().Where(x => listServiceId.Contains(x.ServiceId)).ToListAsync();

            var result = listAppointments.Select(x => new FarvoriteItemReponse
            {
                AppointmentId = x.AppointmentId,
                Title = listService.FirstOrDefault(u=> u.ServiceId == x.ServiceId).ServiceName,
                Price = x.Price,
                Date = x.AppointmentTime?.ToString("dd/MM/yyyy"),
                Payment = int.Parse(x.Payment),
                Status = x.Status
            }).ToList();

            return result;

            //return listAppointments;
        }

        [HttpGet("service/{serviceID}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByServiceID(int serviceID)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }

            var listAppointments = await _context.Appointments
                .AsNoTracking()
                .Where(o => o.ServiceId == serviceID)
                .ToListAsync();

            return listAppointments;
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            if (_context.Appointments == null)
            {
                return NotFound();
            }
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, AppointmentRequest appointmentRequest)
        {
            var appointments = await _context.Appointments.FirstOrDefaultAsync(u => u.AppointmentId == id);
            try
            {
                if (appointments != null)
                {
                    Extenions.CopyObjectData(appointmentRequest, appointments);
                    appointments.ModifiedDate = DateTime.Now;
                    _context.Update(appointments);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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
        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("status/{id}")]
        public async Task<bool> PutStatusAppointment(int id, int status)
        {
            var appointments = await _context.Appointments.FirstOrDefaultAsync(u => u.AppointmentId == id);
            try
            {
                if (appointments != null)
                {
                    appointments.Status = status;
                    appointments.ModifiedDate = DateTime.Now;
                    _context.Update(appointments);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return false;
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(AppointmentRequest appointmentRequest)
        {
            try
            {
                if (_context.Appointments == null)
                {
                    return Problem("Entity set 'DbHealthcareSystemContext.Appointments'  is null.");
                }
                var appointment = new Appointment();
                Extenions.CopyObjectData(appointmentRequest, appointment);
                appointment.Status = 0;
                appointment.CreateDate = DateTime.Now;
                appointment.ModifiedDate = null;
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentId }, appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAppointment(int id)
        {
            if (_context.Appointments == null)
            {
                return false;
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return false;
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool AppointmentExists(int id)
        {
            return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}