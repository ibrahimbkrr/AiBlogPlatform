using BtkAkademiAi.WebApi.Dtos.RegisterDtos;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public RegistersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        { 
            AppUser appUser = new AppUser()
            {
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Title = "Unkown",
                Decscription = "Unkown",
                ImageUrl = "Test"

            };
            await _userManager.CreateAsync(appUser,userRegisterDto.Password);
            return Ok("User created successfully");
        }
    }
}
