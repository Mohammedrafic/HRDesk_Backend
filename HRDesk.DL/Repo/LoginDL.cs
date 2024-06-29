using HRDesk.DL.Context;
using HRDesk.DL.IRepo;
using HRDesk.Models.Request;
using HRDesk.Models.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HRDesk.DL.Repo
{
    public class LoginDL : ILoginDL
    {
        private readonly DbfirstApproachContext _context;
        public LoginDL(DbfirstApproachContext context)
        {
            _context = context;
        }

        public async Task<string> GetOTP(string Email)
        {
            try
            {
                string sOTP = String.Empty;
                if (!Email.IsNullOrEmpty())
                {
                    var existingEmail = await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
                    if (existingEmail != null)
                    {
                        string[] OTP = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                        int OTPLength = 6;
                        string sTempChars = String.Empty;
                        Random rand = new Random();
                        for (int i = 0; i < OTPLength; i++)
                        {
                            int p = rand.Next(0, OTP.Length);
                            sTempChars = OTP[rand.Next(0, OTP.Length)];
                            sOTP += sTempChars;
                        }

                        //// Send OTP through email
                        //using (MailMessage mail = new MailMessage())
                        //{
                        //    mail.From = new MailAddress("mohammedrafic121@gmail.com"); // Replace with your email address
                        //    mail.To.Add(Email);
                        //    mail.Subject = "OTP Verification";
                        //    mail.Body = $"Your OTP is: {sOTP}";

                        //    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com")) // Replace with your SMTP server address
                        //    {
                        //        smtp.Port = 587;
                        //        smtp.Credentials = new NetworkCredential("mohammedrafic121@gmail.com", "mohammed121"); // Replace with your email credentials
                        //        smtp.EnableSsl = false;
                        //        smtp.UseDefaultCredentials = true;
                        //        smtp.Send(mail);
                        //    }
                        //}
                    }
                }
                return sOTP;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = new LoginResponse();
                var existingUser = await _context.Users.Where(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    response.Status = "Success";
                }
                else
                {
                    response.Status = "Error";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
