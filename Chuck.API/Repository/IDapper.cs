using System.Threading.Tasks;
using Chuck.API.Entities;


namespace Chuck.API.Repository
{

    public interface IDapper
    {
        Task<ChuckNorrisJokes> GetChuckNorrisJokeAsync(int? funnyLevel = null);

    }


}