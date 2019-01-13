using System.Threading.Tasks;
using Inclive.Domain.Entities;

namespace Inclive.Application.Repositories
{
    public interface IPlayerReadOnlyRepository
    {
        Task<Player> GetPlayerByEmailAndPassword(string email, string password);
        Task<bool> PlayerWithEmailExist(string email);
    }
}