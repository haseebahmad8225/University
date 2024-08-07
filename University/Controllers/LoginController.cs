using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using University.Migrations;
using University.Model;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         

        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GenerateToken(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("Email",user.Email),
                    new Claim("Id", user.Id.ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                // handle the exception
                throw;
            }
        }

        private string HashPassword(string password, string salt)
        {
            try
            {
                if (password == null)
                {
                    throw new ArgumentNullException(nameof(password));
                }

                if (salt == null)
                {
                    throw new ArgumentNullException(nameof(salt));
                }

                using (var sha256 = SHA256.Create())
                {
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                    return Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                // handle the exception
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Login>> SignUp(SignUp model)
        {
            try
            {
                // Validate the model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Create a new user
                var user = new User
                {
                    Name = model.UserName,
                    Email = model.Email,
                    Password = HashPassword(model.Password, "salt")
                };

                // Save the user to the database
                // ...

                // Generate a token for the user
                var token = GenerateToken(user);

                // Return the token
                return Ok(new Login { Token = token });
            }
            catch (Exception ex)
            {
                // handle the exception
                throw;
            }
        }
    }
}

