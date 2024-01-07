using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jwtService;
        private readonly IEmailService _emailService;
        public JWTController(IJWTService jWTService, IEmailService emailService)
        {
            _jwtService = jWTService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult UserLogin([FromBody] User login)
        {
            
            var token =  _jwtService.userLogin(login);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> SendEmail(Send send)
        {
            try
            {
                // Input validation (you can use data annotations or FluentValidation)
                if (string.IsNullOrWhiteSpace(send.recipientEmail) || string.IsNullOrWhiteSpace(send.subject))
                {
                    return BadRequest("Recipient email and subject are required.");
                }

                // Authentication and authorization checks go here

                // Generate the attachment (invoice) using a service method
                byte[] attachment = _emailService.GenerateInvoice(send);

                // Send the email with the attachment
                await _emailService.SendEmailAsync(send, attachment);

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging and monitoring
                //_logger.LogError(ex, "Email sending failed.");

                // Handle errors and return an appropriate response
                return BadRequest($"Email sending failed: {ex.Message}");
            }
        }


    }
}
