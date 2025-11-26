using EventPass.Domain.Entities.Users;
using EventPass.Domain.Interfaces.Services;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;
    private readonly EventPassDbContext _context;

    public JwtService(IConfiguration config, EventPassDbContext context)
    {
        _config = config;
        _context = context;
    }

    public string GenerateToken(User user)
    {
        var userDB = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email.ToLower() == user.Email.ToLower());
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userDB.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userDB.Email),
            new Claim(ClaimTypes.Role, userDB.Role.Name ?? "User")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}