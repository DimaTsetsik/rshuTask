using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.Abstractions
{
    public interface IImdbService
    {
        Task<ImdbEntity> GetRandomFilm();

        Task<ImdbEntity> GetFilmByName(string filmName);
    }
}
