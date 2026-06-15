using AutoMapper;
using BtkAkademiAi.WebApi.Context;
using BtkAkademiAi.WebApi.Dtos.ArticleDtos;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademiAi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly BlogAIContext _context;
        private readonly IMapper _mapper;

        public ArticlesController(BlogAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ArticleList()
        {
            var articles = await _context.Articles
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .ToListAsync();

            var articleDtos = _mapper.Map<List<ResultArticleWithCategoryDto>>(articles);

            return Ok(articleDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleDto articleDto)
        {
            articleDto.CreatedDate = DateTime.Now;

            var article = _mapper.Map<Article>(articleDto);

            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return Ok("Makale oluşturma başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound("Makale bulunamadı");
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return Ok("Makale silme başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound("Makale bulunamadı");
            }

            var articleDto = _mapper.Map<GetArticleByIdDto>(article);

            return Ok(articleDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle(UpdateArticleDto articleDto)
        {
            if (articleDto == null)
            {
                return BadRequest("Makale bilgisi boş gönderildi");
            }

            var article = await _context.Articles.FindAsync(articleDto.ArticleId);

            if (article == null)
            {
                return NotFound("Makale bulunamadı");
            }

            _mapper.Map(articleDto, article);

            await _context.SaveChangesAsync();

            return Ok("Makale güncelleme başarılı");
        }

        [HttpGet("feature-slider")]
        public async Task<IActionResult> GetFeatureSliderArticles()
        {
            var articles = await _context.Articles
                .Where(a => a.IsFeatureSlider)
                .Include(c => c.Category)
                .Include(b => b.AppUser)
                .ToListAsync();

            var articleDtos = _mapper.Map<List<ResultArticleWithCategoryDto>>(articles);

            return Ok(articleDtos);
        }

        [HttpGet("last-technology-article")]
        public async Task<IActionResult> GetLastTechnologyArticle()
        {
            var categoryId = await _context.Categories
                .Where(x => x.CategoryName == "Teknoloji")
                .Select(x => x.CategoryId)
                .FirstOrDefaultAsync();

            var article = await _context.Articles
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.ArticleId)
                .FirstOrDefaultAsync();

            if (article == null)
            {
                return NotFound("Teknoloji kategorisinde makale bulunamadı");
            }

            var articleDto = _mapper.Map<ResultLastTechnologyDto>(article);

            return Ok(articleDto);
        }

        [HttpGet("last-sports-article")]
        public async Task<IActionResult> GetLastSportsArticle()
        {
            var categoryId = await _context.Categories
                .Where(x => x.CategoryName == "Spor")
                .Select(x => x.CategoryId)
                .FirstOrDefaultAsync();

            var article = await _context.Articles
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.ArticleId)
                .FirstOrDefaultAsync();

            if (article == null)
            {
                return NotFound("Spor kategorisinde makale bulunamadı");
            }

            var articleDto = _mapper.Map<ResultLastSportsDto>(article);

            return Ok(articleDto);
        }

        [HttpGet("last-egitim-article")]
        public async Task<IActionResult> GetLastEgitimArticle()
        {
            var categoryId = await _context.Categories
                .Where(x => x.CategoryName == "Eğitim")
                .Select(x => x.CategoryId)
                .FirstOrDefaultAsync();

            var article = await _context.Articles
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.ArticleId)
                .FirstOrDefaultAsync();

            if (article == null)
            {
                return NotFound("Eğitim kategorisinde makale bulunamadı");
            }

            var articleDto = _mapper.Map<ResultLastEgitimDto>(article);

            return Ok(articleDto);
        }

        [HttpGet("GetLastArticlesByDifferentCategories")]
        public async Task<IActionResult> GetLastArticlesByDifferentCategories()
        {
            var articles = await _context.Articles
                .Include(a => a.Category)
                .ToListAsync();

            var lastArticles = articles
                .GroupBy(a => a.CategoryId)
                .Select(g => g.OrderByDescending(a => a.CreatedDate).FirstOrDefault())
                .Where(a => a != null)
                .OrderByDescending(a => a.CreatedDate)
                .Take(5)
                .ToList();

            var articleDtos = _mapper.Map<List<LastArticleByCategoryDto>>(lastArticles);

            return Ok(articleDtos);
        }

        [HttpGet("GetTrendingArticles")]
        public async Task<IActionResult> GetTrendingArticles()
        {
            var articles = await _context.Articles
                .Where(a => a.IsTrendingStories == true)
                .Include(c => c.Category)
                .Include(b => b.AppUser)
                .ToListAsync();

            var articleDtos = _mapper.Map<List<TrendArticlesDto>>(articles);

            return Ok(articleDtos);
        }

        [HttpGet("GetLastAddedArticles")]
        public async Task<IActionResult> GetLastAddedArticles()
        {
            var article = await _context.Articles
                .Where(a => a.IsLastArticle == true)
                .Include(c => c.Category)
                .Include(b => b.AppUser)
                .FirstOrDefaultAsync();

            if (article == null)
            {
                return NotFound("Son eklenen makale bulunamadı");
            }

            var articleDto = _mapper.Map<LastAddedArticlesDto>(article);

            return Ok(articleDto);
        }

        [HttpGet("GetLastFourArticlesByCategory")]
        public async Task<IActionResult> GetLastFourArticlesByCategory()
        {
            var articles = await _context.Articles
                .Include(c => c.Category)
                .OrderByDescending(y => y.CreatedDate)
                .Take(5)
                .ToListAsync();

            var articleDtos = _mapper.Map<List<GetLastFourArticleByCategoryDto>>(articles);

            return Ok(articleDtos);
        }
    }
}