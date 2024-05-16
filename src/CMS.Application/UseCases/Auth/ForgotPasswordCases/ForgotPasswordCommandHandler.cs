using CMS.Application.Abstractions;
using CMS.Application.UseCases.EmailService;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.Auth.ForgotPasswordCases
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ResponseModel>
    {
        private UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly ICMSDbContext _context;

        public ForgotPasswordCommandHandler(UserManager<User> userManager, IEmailService emailService, ICMSDbContext context)
        {
            _userManager = userManager;
            _emailService = emailService;
            _context = context;
        }

        public async Task<ResponseModel> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Message = "User not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            var newPassword = new Random().Next(100000, 999999).ToString();

            // Update the user's password
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            if (!result.Succeeded)
            {
                return new ResponseModel()
                {
                    Message = "Failed to reset password",
                    IsSuccess = false,
                    StatusCode = 500
                };
            }

            try
            {
                var emailBody = $"Dear {user.FirstName},\n\nYour new password is: {newPassword}.\n\nBest regards,\nThe CMS Team";

                await _emailService.SendEmailAsync(new EmailModel
                {
                    To = request.Email,
                    Subject = "Password Reset",
                    Body = emailBody
                });
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = $"Failed to send password reset email: {ex.Message}",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Message = "Password reset email sent successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }

    }
}
