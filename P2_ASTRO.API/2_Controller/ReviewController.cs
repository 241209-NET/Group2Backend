using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Service;

namespace P2_ASTRO.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService) => _reviewService = reviewService;

    [HttpGet]
    public IActionResult GetAllReviews()
    {
        var reviewList = _reviewService.GetAllReviews();
        if(reviewList is null) return BadRequest("something is wrong at on GetAllReviews()");
        return Ok(reviewList);
    }

    [HttpGet]
    public IActionResult GetReviewById([FromQuery] int reviewId){
        var review = _reviewService.GetReviewById(reviewId);
        if(review is null) return BadRequest("something is wrong at on GetReviewById()");
        return Ok(review);
    }

    [HttpPost]
    public IActionResult CreateNewReview([FromBody] ReviewInDTO newReviewInDTO){
        var review = _reviewService.CreateNewReview(newReviewInDTO);
        if(review is null) return BadRequest("something is wrong at on CreateNewReview()");
        return Ok(review);
    }

    [HttpGet]
    public IActionResult GetReviewsByUserId([FromQuery] int userId){
        var review = _reviewService.GetReviewsByUserId(userId);
        if(review is null) return BadRequest("something is wrong at on GetReviewsByUserId()");
        return Ok(review);
    }
}