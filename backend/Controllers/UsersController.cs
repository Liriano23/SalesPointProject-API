using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsersController(UserManager<IdentityUser> userManager, 
            IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("create")]
        public async Task<ActionResult<AuthResponse>> Create([FromBody] Users user)
        {
            var usuario = new IdentityUser { UserName = user.Email, Email = user.Email };
            var result = await userManager.CreateAsync(usuario, user.Password);

            if (result.Succeeded)
            {
                return await BuildToken(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        
        private async Task<AuthResponse> BuildToken(Users user)
        {
            var claims = new List<Claim>()
            {
                new Claim("email",user.Email)
            };

            var usuario = await userManager.FindByEmailAsync(user.Email);
            var claimsDb = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDb);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AuthResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] Users user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Email, user.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(user);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }


        [HttpPost("makeAdmin")]
        public async Task<ActionResult> MakeAdmin([FromBody] string userId)
        {
            var usuario = await userManager.FindByIdAsync(userId);
            await userManager.AddClaimAsync(usuario, new Claim("role","admin"));
            return NoContent();
        }

        [HttpPost("removeAdmin")]
        public async Task<ActionResult> RemoveAdmin([FromBody] string userId)
        {
            var usuario = await userManager.FindByIdAsync(userId);
            await userManager.RemoveClaimAsync(usuario, new Claim("role", "admin"));
            return NoContent();
        }

        
        //[HttpPost("logout")]
        //public async Task<IActionResult> Logout(string returnUrl = null)
        //{
        //    await signInManager.SignOutAsync();
        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //}

    }
}
