using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace src
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(
      ILogger<AuthController> logger,
      ApplicationDbContext context,
      IConfiguration config
    )
    {
      _logger = logger;
      _context = context;
      _config = config;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
    {
      if (dto.password != dto.passwordRepeat)
      {
        return NotFound(new
        {
          message = "password missmatch"
        });
      }

      using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
      {
        try
        {
          Person person = new Person();
          this._context.Set<Person>().Attach(person);

          User user = new User();
          user.username = dto.username;
          user.person = person;
          user.accounts = new System.Collections.Generic.List<Account>();
          user.isActive = true;
          this._context.Set<User>().Attach(user);

          Account account = new Account();
          account.additionalType = "local";
          account.email = dto.email;
          account.password = dto.password;
          account.userId = user.Id;
          this._context.Set<Account>().Attach(account);

          user.accounts.Add(account);
          await this._context.SaveChangesAsync();
          await transaction.CommitAsync();
          return new UserDto(user);
        }
        catch (Exception e)
        {
          await transaction.RollbackAsync();
          throw e;
        }
      }
    }

    [Route("Login")]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Login(LoginDto dto)
    {
      User user = await this._context.Users
                .Where(u => dto.identifier == u.username && !u.isDeleted && !u.isDisabled && u.isActive)
                .Include("accounts")
                .Where(u => u.accounts.Any(a => a.password == dto.password))
                .Include("person")
                .FirstOrDefaultAsync();

      if (!(user is null))
      {
        return new GenerateJWT(Login(user));
      }

      Account account = await this._context.Accounts
          .Where(a => a.email == dto.identifier && a.password == dto.password)
          .FirstOrDefaultAsync();

      if (account is null)
      {
        return Unauthorized();
      }
      else
      {
        User sUSer = await this._context.Users
            .Where(u => u.Id == account.userId && !u.isDeleted && !u.isDisabled && u.isActive)
            .Include("person")
            .FirstOrDefaultAsync();

        return new UserDto(sUSer);
      }
    }

    private string GenerateJWT(Login userInfo)    
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    

        var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.user.username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.user.email),
                new Claim("Date", DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            

            var token = new JwtSecurityToken(_config["JWT:Issuer"],    
              _config["JWT:Issuer"],    
              claims,    
              expires: DateTime.Now.AddHours(2),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }
  }

  public class RegisterDto
  {
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string passwordRepeat { get; set; }
  }

  public class LoginDto
  {
    public string identifier { get; set; }
    public string password { get; set; }
  }
}
