using BlazorProject.Service.IService;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Security.Claims;
using BlazorProject.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorProject.Service
{
    public class EmailService : IEmailService
    {
        public NavigationManager _navigationManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;
        public EmailService(UserManager<IdentityUser> userManager, ApplicationDbContext context, 
            IHttpContextAccessor httpContextAccessor, IEmailSender emailSender)
        {
            _userManager = userManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
        }
        public async Task SendEmailAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            await _emailSender.SendEmailAsync(user.Email, "Task Status has been changed", "TaskStatus changed");
        }
    }
}
