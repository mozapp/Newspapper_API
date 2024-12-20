using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewspapperAPI.Models.Entities.BlogEntities;
using NewspapperAPI.Repository.Services;

namespace NewspapperAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var article = await _articleRepository.GetByIdAsync(id);
                if (article == null) return NotFound();
                return Ok(article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAticles()
        {
            try
            {
                var article = await _articleRepository.GetAllAsync();
                return Ok(article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            if (article == null)
            {
                return BadRequest("Article cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(article.Title) || string.IsNullOrWhiteSpace(article.Content))
            {
                return BadRequest("Title and Content cannot be empty.");
            }

            try
            {
                await _articleRepository.AddAsync(article);
                return CreatedAtAction(nameof(GetById), new { Id = article.ArticleId }, article);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erorr: {ex.Message}");
            }
        }

    }
}