using Artists_Reviews.Data;
using Artists_Reviews.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Artists_Reviews.Services
{
    public class SyncArtist
    {
        private readonly ApplicationDBContext _context;

        public SyncArtist(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task SyncArtistsAsync(List<Artist> artistsFromApi)
        {
            var existingArtistIds = await _context.Artists.Select(a => a.Id).ToListAsync();
            var newArtists = artistsFromApi.Where(a => !existingArtistIds.Contains(a.Id)).ToList();

            if (newArtists.Any())
            {
                _context.Artists.AddRange(newArtists);
                await _context.SaveChangesAsync();
            }
        }
    }
}
