using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.Abstractions
{
    public interface IMoviedbService
    {
        Task<ThemoviedbEntity> GetRandomFilm();
    }
}