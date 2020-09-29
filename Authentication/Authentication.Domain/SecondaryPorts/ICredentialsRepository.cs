using System.Threading.Tasks;

namespace Authentication.Domain.SecondaryPorts
{
    public interface ICredentialsRepository
    {
        Task<User?> GetUserAsync(string login);
        Task SaveUserAsync(User user);
    }
}
