namespace BlazorBasicApp.Services.Game
{
    public interface IGameService
    {
        Task<List<Entities.Game>> getAllGames();
        Task<Entities.Game> AddGame(Entities.Game game);
        Task<Entities.Game> GetGameById(int Id);
        Task<Entities.Game> EditGame(int Id, Entities.Game game);
        Task<bool> DeleteGame(int Id);
    }
}
