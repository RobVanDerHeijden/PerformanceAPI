using Drafter.Model;

namespace Drafter.Interfaces.Authentication
{
    public interface ITokenManager
    {
        string GetToken(User user);
    }
}