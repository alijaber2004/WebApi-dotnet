using Artists_Reviews.Dtos.Artist;
using Artists_Reviews.Models;

namespace Artists_Reviews.Interface
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task<Artist> CreateAsync(Artist artistModel);
        Task<Artist> UpdateAsync(int id, UpdateArtistDto artistDto);
        Task<Artist> DeleteAsync(int id);
        Task<bool> ArtistExists(int id);
    }
}
