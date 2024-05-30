using Entidades;
using Microsoft.IdentityModel.Tokens;
using Services.MyDbContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Services.Login
{
    public class SvLogin : ISvLogin
    {
        private readonly MyContext _context;

        public SvLogin(MyContext context)
        {
            _context = context;
        }

        private string generateToken(string username, string role, string secret)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secret);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30), 
                SigningCredentials = credentialsToken,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenMake = tokenHandler.WriteToken(tokenConfig);

            return tokenMake;
        }

        public async Task<UserResponse> ReturnToken(UserRequest request, string secret)
        {
            var user = _context.Users.FirstOrDefault(
                u => u.UserName == request.Username && u.Password == request.Password
            );

            if (user == null)
            {
                return await Task.FromResult<UserResponse>(null);
            }

            var role = _context.Roles.FirstOrDefault(item => item.Id == user.RolId);

            if (role == null)
            {
                return await Task.FromResult<UserResponse>(null);
            }

            string tokenMake = generateToken(user.UserName, role.Nombre, secret);

            return new UserResponse() { Token = tokenMake, Message = "Ok" };
        }
    }
}
