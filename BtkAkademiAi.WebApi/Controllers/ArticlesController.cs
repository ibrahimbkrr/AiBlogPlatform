using AutoMapper;
using BtkAkademiAi.WebApi.Context;
using BtkAkademiAi.WebApi.Dtos.ArticleDtos;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult ArticleList()
        {
            var articles = _context.Articles.Include(x => x.Category).ToList();
            var articleDtos = _mapper.Map<List<ResultArticleWithCategoryDto>>(articles);
            return Ok(articleDtos);
        }

        [HttpPost]
        public IActionResult CreateArticle(CreateArticleDto articleDto)
        {
            articleDto.CreatedDate = DateTime.Now;
            var article = _mapper.Map<Article>(articleDto);
            _context.Articles.Add(article);
            _context.SaveChanges();
            return Ok("Makale oluşturma başarılı");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound("Makale bulunamadı");
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();
            return Ok("Makale silme başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetArticleById(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound("Makale bulunamadı");
            }
            var articleDto = _mapper.Map<GetArticleByIdDto>(article);
            return Ok(articleDto);

        }

        [HttpPut]
        public IActionResult UpdateArticle(UpdateArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            _context.Articles.Update(article);
            _context.SaveChanges();
            return Ok("Makale güncelleme başarılı");
        }

        [HttpGet("feature-slider")]
        public IActionResult GetFeatureSliderArticles()
        {
            var articles = _context.Articles
                .Where(a => a.IsFeatureSlider)          
                .Include(c => c.Category)
                .Include(b => b.AppUser)
                .ToList();

            var articleDtos = _mapper.Map<List<ResultArticleWithCategoryDto>>(articles);

            return Ok(articleDtos);
        }

        [HttpGet("last-technology-article")]
        public IActionResult GetLastTechnologyArticle()
        {
            var categoryId = _context.Categories
                .Where(x => x.CategoryName == "Teknoloji")
                .Select(x => x.CategoryId)
                .FirstOrDefault();
            var articles = _context.Articles
                .Where(x => x.CategoryId == categoryId)
                .Include(c => c.AppUser)
                .OrderByDescending(y => y.ArticleId)
                .Take(1).FirstOrDefault();
            return Ok(_mapper.Map<ResultLastTechnologyDto>(articles));
        }

        [HttpGet("last-sports-article")]
        public IActionResult GetLastSportsArticle()
        {
            var categoryId = _context.Categories
                .Where(x => x.CategoryName == "Spor") 
                .Select(x => x.CategoryId)
                .FirstOrDefault();
            var articles = _context.Articles
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(y => y.ArticleId)
                 .Include(c => c.AppUser)
                .Take(1).FirstOrDefault();
            return Ok(_mapper.Map<ResultLastSportsDto>(articles));
        }

        [HttpGet("last-egitim-article")]
        public IActionResult GetLastEgitimArticle()
        {
            var categoryId = _context.Categories
                .Where(x => x.CategoryName == "Eğitim")
                .Select(x => x.CategoryId)
                .FirstOrDefault();
            var articles = _context.Articles
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(y => y.ArticleId)
                .Include(c => c.AppUser)
                .Take(1).FirstOrDefault();
            return Ok(_mapper.Map<ResultLastEgitimDto>(articles));
        }
        [HttpGet("GetLastArticlesByDifferentCategories")]
        public IActionResult GetLastArticlesByDifferentCategories()
        {
            var articles = _context.Articles
                .Include(a => a.Category)
                .ToList()
                .GroupBy(a => a.CategoryId)
                .Select(g => g.OrderByDescending(a => a.CreatedDate).FirstOrDefault())
                .Where(a => a != null)
                .OrderByDescending(a => a.CreatedDate)
                .Take(5)
                .ToList();

            var articleDtos = _mapper.Map<List<LastArticleByCategoryDto>>(articles);

            return Ok(articleDtos);
        }
    }
}
