
using AutoMapper;
using BtkAkademiAi.WebApi.Context;
using BtkAkademiAi.WebApi.Dtos.CategoryDtos;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BlogAIContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(BlogAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori ekleme başarılı");


        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori silme başarılı");
        }
        [HttpGet("ID")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
          var values = _mapper.Map<Category>(updateCategoryDto);
            
            _context.Categories.Update(values);
            _context.SaveChanges();
            return Ok("Kategori güncelleme başarılı");

        }

    }
}
