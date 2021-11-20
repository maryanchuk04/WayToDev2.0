
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace WayToDev2
{
    public class AuthOptions
    {
        public const string ISSUER = "MaksAuthServer";
        public const string AUDIENCE = "MaksAuthClient";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}

