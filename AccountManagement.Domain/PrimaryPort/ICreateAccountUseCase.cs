using System.Threading.Tasks;

namespace AccountManagement.Domain.PrimaryPort
{
    public interface ICreateAccountUseCase
    {
        Task CreateAsync(Account account);
    }
}
