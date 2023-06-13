using Authentication.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NekoNetGPT.API;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptionsSnapshot<JwtSettings> jwtSettings;
        private readonly UserManager<User> userManager;

        public AuthController(IOptionsSnapshot<JwtSettings> jwtSettings, UserManager<User> userManager)
        {
            this.jwtSettings = jwtSettings;
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> EmailAndPasswordRegister()
        {


            // Create user object
            User nekoUser = new()
            {
                UserName = "test",
                Email = "a@b.c"
            };

            // Add user to database
            var createResult = await userManager.CreateAsync(nekoUser, "strong");

            // Return 500InternalServerError if not succeeded
            if (createResult.Errors.Any())
            {
                return BadRequest(createResult.Errors.Select(x => x.Description).ToList());
            }

            //var addRoleResult = await userManager.AddToRoleAsync(nekoUser, Roles.User);

            //if (addRoleResult.Errors.Any())
            //{
            //    return BadRequest(addRoleResult.Errors.Select(x => x.Description).ToList());
            //}

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginWithUsernameAndPassword()
        {
            // Extract UserName and PassWord from request
            var userName = "test";
            var password = "strong";

            // Must provide UserName and PassWord
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            //{
            //    return BadRequest("Login failed, please check your Username and Password");
            //}

            //var user = await userManager.FindByNameAsync(userName);

            // No such user
            //if (user == null)
            //{
            //    return NotFound("Login failed, please check your Username and Password");
            //}

            // Check if the account is already locked
            //if (await userManager.IsLockedOutAsync(user))
            //{
            //    return BadRequest("Account locked!");
            //}

            // Check password
            //var result = await userManager.CheckPasswordAsync(user, password);

            //if (!result)
            //{
            //    // If password is wrong, increase the failed counter
            //    await userManager.AccessFailedAsync(user);
            //    return BadRequest("Login failed, please check your Username and Password");
            //}

            // Passed password check, remove the failed counter
            //await userManager.ResetAccessFailedCountAsync(user);

            //var roles = await userManager.GetRolesAsync(user);

            //var securityStamp = await userManager.GetSecurityStampAsync(user);

            // Generate jwt

            // Make claims
            List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, userName),
            //new Claim(ClaimTypes.Email, user.Email!),

        };

            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            // Private key
            string key = jwtSettings.Value.SecretKey ?? throw new Exception();

            // Expire time
            DateTime expires = DateTime.UtcNow.AddDays(jwtSettings.Value.ExpireDays);

            // Convert key to bytes, build symmetric key and then generate credentials
            byte[] secBytes = Encoding.UTF8.GetBytes(key);
            var secKey = new SymmetricSecurityKey(secBytes);
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);

            // Build a TokenDescriptor
            var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: credentials);

            // Build jwt
            string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(jwt);
        }
    }
}
