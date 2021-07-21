using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApiAPP.Services;

namespace WebApiAPP.Authentication
{
    public interface IUserService
    {
        TokenResponse Authenticate(string user, string password);
        string RefreshToken(string token);
    }
}
