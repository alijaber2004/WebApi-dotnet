using Artists_Reviews.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Artists_Reviews.Models;
using Artists_Reviews.Dtos.Artist;
using Artists_Reviews.Mappers;
using Artists_Reviews.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Artists_Reviews.Interface;

namespace Artists_Reviews.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IArtistRepository _artistRepo;
        private readonly ArtistService _artistService;
        private readonly SyncArtist _syncArtistService;
        public ArtistController(ApplicationDBContext context, IArtistRepository ArtistRepo, ArtistService artistService, SyncArtist syncArtistService)
        {
            _context = context;
            _artistRepo = ArtistRepo;
            _artistService = artistService;
            _syncArtistService = syncArtistService;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncArtists()
        {
            var artistsFromApi = await _artistService.GetArtistsFromApiAsync();
            await _syncArtistService.SyncArtistsAsync(artistsFromApi);
            return Ok("Artists synchronized successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistRepo.GetAllAsync();
                
            var artistDto = artists.Select(s => s.ToArtistDto());

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var artist = await _artistRepo.GetByIdAsync(id);

            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist.ToArtistDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArtistDto artistDto)
        {
            var ArtistModel = artistDto.ToArtistFromCreateDTO();

            await _artistRepo.CreateAsync(ArtistModel);

            return CreatedAtAction(nameof(GetById), new { id = ArtistModel.Id }, ArtistModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateArtistDto updateDto )
        {
            var ArtistModel = await _artistRepo.UpdateAsync(id, updateDto);

            if(ArtistModel == null)
            {
                return NotFound();
            }

            return Ok(ArtistModel.ToArtistDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var ArtistModel = await _artistRepo.DeleteAsync(id);

            if (ArtistModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
