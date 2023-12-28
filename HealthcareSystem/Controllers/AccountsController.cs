using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Models;
using HealthcareSystem.ModelViews;
using HealthcareSystem.Messages;
using HealthcareSystem.Extensions;
using System.Collections;
using static HealthcareSystem.ModelViews.ServiceView;
using static HealthcareSystem.ModelViews.FarvoriteItem;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DbHealthcareSystemContext _context;

        public AccountsController(DbHealthcareSystemContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginReponse>> LoginAcoount(LoginRequest loginModel)
        {
            try
            {
                var existingUser = await _context.Accounts.FirstOrDefaultAsync(u => u.UserName.Trim().ToLower() == loginModel.UserName.Trim().ToLower());
                var message = string.Empty;
                if (existingUser != null)
                {
                    if (!Extenions.VerifyPassword(loginModel.PassWord, existingUser.Password))
                    {
                        return new LoginReponse
                        {
                            User = null,
                            ShowMessages = ShowMessages.PasswordIsFail
                        };
                    }

                    if (existingUser.UserRoleNo == 1)
                    {
                        var listServices = new List<Service>();
                        var listAppointments = new List<Appointment>();
                        var staff = await _context.Staffs.FirstOrDefaultAsync(u => u.StaffNo.Trim() == existingUser.UserNo.Trim());
                        if (staff.Active == true)
                        {
                            listServices = await _context.Services.AsNoTracking().Where(u => u.StaffId == staff.StaffId).ToListAsync();
                            var listServicesID = listServices.Select(u => u.ServiceId).ToList();
                            listAppointments = await _context.Appointments
                               .AsNoTracking()
                               .Where(u => listServicesID.Contains((int)u.ServiceId))
                               .ToListAsync();
                          
                        }


                        if (staff != null)
                        {
                            var result = listAppointments.Select(x => new FarvoriteItemReponse
                            {
                                AppointmentId = x.AppointmentId,
                                Title = listServices.FirstOrDefault(u => u.ServiceId == x.ServiceId).ServiceName,
                                Price = x.Price,
                                Date = x.AppointmentTime?.ToString("dd/MM/yyyy"),
                                Payment = int.Parse(x.Payment),
                                Status = x.Status
                            }).ToList();
                            return new LoginReponse
                            {
                                User = staff,
                                Services = listServices,
                                Appointments = result,
                                IsLoggedIn = staff.Active,
                                ShowMessages = staff.Active == true ? ShowMessages.LoginSuccess : ShowMessages.AccountExploration,
                            };
                        }

                    }
                    else if (existingUser.UserRoleNo == 2)
                    {
                        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNo.Trim() == existingUser.UserNo.Trim());
                        var listServices = await _context.Services.AsNoTracking().ToListAsync();
                        //var listAppointments = await _context.Appointments
                        //   .AsNoTracking()
                        //   .Where(u => u.UserId == user.UserId)
                        //   .ToListAsync();

                        if (user != null)
                        {
                            return new LoginReponse
                            {
                                User = user,
                                Services = listServices,
                                Appointments = null,
                                IsLoggedIn = true,
                                ShowMessages = ShowMessages.LoginSuccess,

                            };
                        }
                    }
                }



                return new LoginReponse
                {
                    User = null,
                    Services = null,
                    Appointments = null,
                    ShowMessages = ShowMessages.UserIsNotExist
                };


            }
            catch (Exception ex)
            {
                return new LoginReponse
                {
                    ShowMessages = ex.Message
                };

            }
        }

        [HttpPut("accept")]
        public async Task<bool> AcceptAccount(int id, bool isLogin)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AcoountId == id);
            if(account != null)
            {
                var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.StaffNo.Trim() == account.UserNo.Trim());
                staff.Active = isLogin;
                _context.Staffs.Update(staff);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        [HttpGet("AcceptAccount")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAcceptAccount()
        {
            var staffs = await _context.Staffs.AsNoTracking().Where(x => (bool)!x.Active).ToListAsync();
            if (staffs != null && staffs.Count > 0)
            {
                var listUserNo = staffs.Select(x => x.StaffNo.Trim()).ToList();
                var accountAccept = await _context.Accounts.AsNoTracking().Where(x => listUserNo.Contains(x.UserNo.Trim()) && x.UserRoleNo == 1).ToListAsync();
                return accountAccept;
  
            }
            return null;

        }

        [HttpPost("register")]
        public async Task<RegisterReponse> RegisterAcoount(RegisterRequest registerRequest)
        {
            try
            {

                var existingUser = await _context.Accounts.FirstOrDefaultAsync(u => u.Email.Trim().ToLower() == registerRequest.Email.Trim().ToLower());
                if (existingUser != null)
                {
                    return new RegisterReponse
                    {
                        IsError = false,
                        ShowMessages = ShowMessages.UserIsExist,
                    };
                }
                var account = new Account();
                Extenions.CopyObjectData(registerRequest, account);
                account.Password = Extenions.HashPassword(account.Password);
                account.CreateDate = DateTime.Now;
                account.UserName = account.Email;

                // sale
                if (account.UserRoleNo == 1)
                {
                    var staff = new Staff();
                    staff.FirstName = registerRequest.FirstName;
                    staff.LastName = registerRequest.LastName;
                    staff.Email = account.Email;
                    staff.UserRoleNo = account.UserRoleNo;
                    staff.Active = false;
                    staff.StaffNo = Guid.NewGuid().ToString().Trim();
                    account.UserNo = staff.StaffNo.Trim();
                    _context.Staffs.Add(staff);
                }
                // user
                else if (account.UserRoleNo == 2)
                {
                    var user = new User();
                    user.FirstName = registerRequest.FirstName;
                    user.LastName = registerRequest.LastName;
                    user.Email = account.Email;
                    user.UserRoleNo = account.UserRoleNo;
                    user.Active = true;
                    user.UserNo = Guid.NewGuid().ToString().Trim();
                    account.UserNo = user.UserNo.Trim();
                    _context.Users.Add(user);

                }
                _context.Accounts.Add(account);

                await _context.SaveChangesAsync();


                return new RegisterReponse
                {
                    IsError = true,
                    ShowMessages = ShowMessages.RegisterSuccess,
                };
            }
            catch (Exception ex)
            {

                return new RegisterReponse
                {
                    IsError = false,
                    ShowMessages = ex.Message,
                };
            }
        }
    }
}
