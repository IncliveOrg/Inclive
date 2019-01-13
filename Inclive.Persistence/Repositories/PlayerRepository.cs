using System.Threading.Tasks;
using Inclive.Application.Repositories;
using Inclive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inclive.Persistence.Repositories
{
    public class PlayerRepository : IPlayerReadOnlyRepository, IPlayerWriteOnlyRepository
    {
        private readonly IncliveDbContext _dbContext;

        public PlayerRepository(IncliveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Player> GetPlayerByEmailAndPassword(string email, string password)
        {
            return await _dbContext.Players.FirstOrDefaultAsync(p =>
                p.Email.Equals(email) && p.Password.Equals(password));
        }

        public async Task<bool> PlayerWithEmailExist(string email)
        {
            return await _dbContext.Players.AnyAsync(p => p.Email.Equals(email));
        }

        public async Task CreatePlayer(Player player)
        {
            await _dbContext.Players.AddAsync(player);
            await _dbContext.SaveChangesAsync();
        }
    }
}
