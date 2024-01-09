using Business.Utilities.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Results
{
    public class AuthResult:IAuthResult
    {
        public int UserId { get; }
        public string UserName { get; }
        public AccessToken AccessToken { get; }

        public AuthResult(int userId, string userName, AccessToken token)
        {
            UserId = userId;
            UserName = userName;
            AccessToken = token;
        }
    }
}
