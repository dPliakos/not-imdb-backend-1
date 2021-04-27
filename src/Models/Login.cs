using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;

namespace src
{
    public class Login
    {
        public User user { get; set; }
        public JwtSecurityToken token { get; set; }
        //public DateTime Date { get; set; } = DateTime.Now;
    }
}