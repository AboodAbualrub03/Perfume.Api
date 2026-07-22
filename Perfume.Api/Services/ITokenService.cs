
using Perfume.Api.Models;

namespace Perfume.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
