using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication2.Token
{
    public class AuthOptions
    {
        public const string ISSUER = "LIZA"; // издатель токена
        public const string AUDIENCE = "Stupid_User"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1440; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}