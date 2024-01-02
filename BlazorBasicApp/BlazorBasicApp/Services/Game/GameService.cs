using BlazorBasicApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorBasicApp.Services.Game
{
    public class GameService : IGameService
    {
        private readonly DataContext _Context;

        public GameService(DataContext dbContext)
        {
            _Context = dbContext;
        }

        public async Task<Entities.Game> AddGame(Entities.Game game)
        {
            _Context.Games.Add(game);
            await _Context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGame(int Id)
        {
            var dbGame= _Context.Games.FirstOrDefault(x => x.Id == Id);
            if(dbGame != null)
            {
                _Context.Games.Remove(dbGame);
                await _Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Entities.Game> EditGame(int Id, Entities.Game game)
        {
            var dbGame = _Context.Games.FirstOrDefault(x => x.Id == Id);
            if (dbGame != null)
            {
                dbGame.Name=game.Name;
                _Context.Update(dbGame);
                _Context.SaveChanges();
                return dbGame;
            }
            throw new Exception("Game Not Found");
        }

        public async Task<List<Entities.Game>> getAllGames()
        {
            return await _Context.Games.ToListAsync();
        }

        public async Task<Entities.Game> GetGameById(int Id)
        {
            return await _Context.Games.FindAsync(Id);
        }
    }
}
