using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DemoAPI.Tools
{
   public class TokenManager
   {
      private string _secretKey;
        public TokenManager(IConfiguration config)
        {
         _secretKey = config.GetSection("tokenInfo").GetSection("secretKey").Value;
    //    }
    //  public string GenerateToken(User user) 
    //  {
    //     SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
    //     SigningCredentials credentials = new SigningCredentials(securityKey, a);
    //  }
    //}
}
