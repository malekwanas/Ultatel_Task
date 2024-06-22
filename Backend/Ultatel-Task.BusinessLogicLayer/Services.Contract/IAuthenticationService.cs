using Microsoft.AspNetCore.Identity;
using Ultatel_Task.Models;

namespace Ultatel_Task.BusinessLogicLayer.Services.Contract
{
    public interface IAuthenticationService
    {
        Task<string> CreateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager);
    }
}
