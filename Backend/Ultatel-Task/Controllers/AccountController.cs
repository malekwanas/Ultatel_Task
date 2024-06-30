using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ultatel_Task.BusinessLogicLayer.Services.Contract;
using Ultatel_Task.DataAccessLayer.Repository.Contract;
using Ultatel_Task.DataAccessLayer.DTO;
using Ultatel_Task.Models;

namespace Ultatel_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericRepo<Admin> _adminRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationService _authService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IGenericRepo<Admin> adminRepository,
            SignInManager<ApplicationUser> signInManager,
            IAuthenticationService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminRepository = adminRepository;
            _signInManager = signInManager;
            _authService = authService;
        }
        //---------------------------------------------------------------
        [HttpPost("Register")]
        public async Task<IActionResult> Registration(RegisterDTO model)
        {
            var user = new ApplicationUser
            {
                UserName = model.AdminName,
                Email = model.Email,
            };

            var admin = new Admin
            {
                ApplicationUser = user,
                UserId = user.Id,
                AdminName = model.AdminName
            };

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                await _roleManager.CreateAsync(role);
            }

            await _adminRepository.AddAsync(admin);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return Ok(model);
            }

            return BadRequest("Registration failed");
        }
        //---------------------------------------------------------------
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized();

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return Ok(new UserDTO
            {
                DisplayName = user.UserName,
                Email = user.Email,
                Token = token
            });
        }
        //---------------------------------------------------------------
    }
}
