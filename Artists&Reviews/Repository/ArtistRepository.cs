using Artists_Reviews.Data;
using Artists_Reviews.Dtos.Artist;
using Artists_Reviews.Interface;
using Artists_Reviews.Models;
using Microsoft.EntityFrameworkCore;

namespace Artists_Reviews.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDBContext _context; 
        public ArtistRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public Task<bool> ArtistExists(int id)
        {
            return _context.Artists.AnyAsync(a => a.Id == id);
        }

        public async Task<Artist> CreateAsync(Artist artistModel)
        {
            await _context.Artists.AddAsync(artistModel);
            await _context.SaveChangesAsync();
            return artistModel;
        }

        public async Task<Artist?> DeleteAsync(int id)
        {
            var artistModel = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);

            if (artistModel == null)
            {
                return null;
            }

            _context.Artists.Remove(artistModel);
            await _context.SaveChangesAsync();

            return artistModel;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _context.Artists.Include(c => c.Reviews).ToListAsync();
        }

        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Artists.Include(c => c.Reviews).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Artist> UpdateAsync(int id, UpdateArtistDto artistDto)
        {
            var existingArtist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);

            if (existingArtist == null) {
                return null;
            }

            existingArtist.Position = artistDto.Position;
            existingArtist.Name = artistDto.Name;
            existingArtist.PictureUrl = artistDto.PictureUrl;

            await _context.SaveChangesAsync();

            return existingArtist;

        }
    }
}
