using Artists_Reviews.Dtos.Artist;
using Artists_Reviews.Models;

namespace Artists_Reviews.Mappers
{
    public static class ArtistMappers
    {
        public static ArtistDto ToArtistDto(this Artist artistModel)
        {
            return new ArtistDto
            {
                Id = artistModel.Id,
                Name = artistModel.Name,
                PictureUrl = artistModel.PictureUrl,
                Position = artistModel.Position,
                Reviews = artistModel.Reviews.Select(c => c.ToReviewDto()).ToList(),
            };
        }
        // when adding you can not pass a dto you need to return a main object
        public static Artist ToArtistFromCreateDTO(this CreateArtistDto ArtistDto)
        {
            return new Artist
            {
                Id = ArtistDto.Id,
                Name = ArtistDto.Name,
                PictureUrl = ArtistDto.PictureUrl,
                Position = ArtistDto.Position,
            };
        }
    }   
}
