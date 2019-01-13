using System.Threading.Tasks;
using Inclive.Domain.Entities;

namespace Inclive.Application.Repositories
{
    public interface IPlayerWriteOnlyRepository
    {
        Task CreatePlayer(Player player);
    }
}