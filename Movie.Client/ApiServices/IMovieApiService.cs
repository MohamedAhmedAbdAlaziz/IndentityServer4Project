
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Client.Models;
namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movies.Client.Models.Movie>> GetMovies();
        Task<Movies.Client.Models.Movie> GetMovie(string id);
        Task<Movies.Client.Models.Movie> CreateMovie(Movies.Client.Models.Movie movie);
        Task<Movies.Client.Models.Movie> UpdateMovie(Movies.Client.Models.Movie movie);
        Task DeleteMovie(int id);
      //  Task<Movies.Client.Models.UserInfoViewModel> GetUserInfo();
    }
}
