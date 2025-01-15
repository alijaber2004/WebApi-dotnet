using Artists_Reviews.Dtos.Artist;
using Artists_Reviews.Dtos.Review;
using Artists_Reviews.Interface;
using Artists_Reviews.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artists_Reviews.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IArtistRepository _artistRepo;
        // for email sending
        private readonly IEmailService _emailService;

        public ReviewController(IReviewRepository reviewRepo, IArtistRepository artistRepo, IEmailService emailService)
        {
            _artistRepo = artistRepo;
            _reviewRepo = reviewRepo;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewRepo.GetAllAsync();

            var reviewDto = reviews.Select(s => s.ToReviewDto());

            return Ok(reviewDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var review = await _reviewRepo.GetByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review.ToReviewDto());
        }

        [HttpPost("{ArtistId}")]
        public async Task<IActionResult> Create([FromRoute] int ArtistId, CreateReviewDto reviewDto)
        {
            if(!await _artistRepo.ArtistExists(ArtistId))
            {
                return BadRequest("Artist does not exist");
            }

            var reviewModel = reviewDto.ToReviewFromCreate(ArtistId);
            await _reviewRepo.CreateAsync(reviewModel);

            //var receiver = "aj580581@gmail.com";
            //var subject = "Test";
            //var message = "review added";

            //await _emailService.SendEmailAsync(receiver, subject, message);
            return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]UpdateReviewDto updateDto)
        {
            var review = await _reviewRepo.UpdateAsync(id, updateDto.ToReviewFromUpdate());

            if(review == null)
            {
                return NotFound("Review not found");
            }

            return Ok(review.ToReviewDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var reviewModel = await _reviewRepo.DeleteAsync(id);

            if(reviewModel == null)
            {
                return NotFound("review does not exist");
            }

            return Ok(reviewModel);
        }
    }
}
