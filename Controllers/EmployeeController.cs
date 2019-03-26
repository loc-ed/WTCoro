using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WTCoro_AW.Models;
using System.Security.Cryptography;
using System.Net.Mail;
/*
namespace WTCoro_AW.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Person
        [HttpGet]
        public ActionResult Registration()
        {
            EmployeeDTO e = new EmployeeDTO();
            return View(e);
        }

        [HttpPost]
        public ActionResult Registration(EmployeeDTO employee)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
                {
                    //not quite sure what this is about tbh as pertaining to the db
                    //but gonna use it as an activation code in email verification
                    employee.rowguid = Guid.NewGuid();

                    
   
                    //person.Password.PasswordHash = Crypto.Hash(person);

                    if (db.People.Any(x => x.EmailAddress.EmailAddress1 == employee.EmailAddress1))
                    {
                        message = "Email already exists.";
                        return View("Registration", employee);
                    }
                    else
                    {
                        db.Employees.Add(employee);
                        db.SaveChanges();

                        SendVerificationLinkEmail(employee.EmailAddress1, employee.rowguid.ToString(), employee.Password1);
                        message = "Registration successfully done. Account activation link " +
                            " has been sent to your email address:" + employee.EmailAddress1;

                    }

                }
            }
            else
            {
                message = "Invalid request";
            }

            ModelState.Clear();
            ViewBag.Message = message;
            return View("Registration", new Person());
        }



      
    //  private void SendVerificationLinkEmail(ICollection<EmailAddress> emailAddresses, string v)
    //  {
    //      throw new NotImplementedException();
    //  }
       






        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string password)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("CFredericks@Coronation.com", "WTCoro");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = password; 
            string subject = "Your account is successfully created!";

            string body = "<br/><br/>We are excited to tell you that your WTCoro account is" +
                " successfully created. Please click on the below link to verify your account" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}

    */