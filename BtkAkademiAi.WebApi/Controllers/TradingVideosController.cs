using AutoMapper;
using BtkAkademiAi.WebApi.Context;
using BtkAkademiAi.WebApi.Dtos.TradingVideosDtos;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademiAi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradingVideosController : ControllerBase
    {
        private readonly BlogAIContext _context;
        private readonly IMapper _mapper;

        public TradingVideosController(BlogAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TradingVideoList()
        {
            var tradingVideos = _context.TradingVideos
                .Include(c => c.Category)
                .Include(b => b.AppUser)
                .ToList();
            var tradingVideoDtos = _mapper.Map<List<ResultTradingVideoDto>>(tradingVideos);
               return Ok(tradingVideoDtos);
        }

        [HttpGet("featured")]
        public IActionResult GetFeaturedTradingVideos()
        {
            var featuredTradingVideos = _context.TradingVideos
                .Include(c => c.Category)
                .Include(b => b.AppUser)
                .Where(tv => tv.IsFeature)
                .FirstOrDefault();
            var featuredTradingVideoDto = _mapper.Map<ResultTradingVideoDto>(featuredTradingVideos);
            return Ok(featuredTradingVideoDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTradingVideo(CreateTradingVideoDto dto)
        {
            var tradingVideo = _mapper.Map<TradingVideo>(dto);

            tradingVideo.CreatedDate = DateTime.UtcNow;

            await _context.TradingVideos.AddAsync(tradingVideo);
            await _context.SaveChangesAsync();

            return Ok("Trading video başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteTradingVideo(int id)
        {
            var tradingVideo = _context.TradingVideos.Find(id);
            if (tradingVideo == null)
            {
                return NotFound("Trading video bulunamadı");
            }
            _context.TradingVideos.Remove(tradingVideo);
            _context.SaveChanges();
            return Ok("Trading video silme başarılı");
        }
        [HttpGet("GetTradingVideo")]
        public IActionResult GetTradingVideo(int id)
        {
            var tradingVideo = _context.TradingVideos
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .FirstOrDefault(x => x.TradingVideoId == id);

            if (tradingVideo == null)
            {
                return NotFound("Trading video bulunamadı");
            }

            var result = _mapper.Map<ResultTradingVideoDto>(tradingVideo);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTradingVideo(UpdateTradingVideoDto dto)
        {
            var value = _context.TradingVideos
                .FirstOrDefault(x => x.TradingVideoId == dto.TradingVideoId);

            if (value == null)
                return NotFound("Trading video bulunamadı");

            value.VideoTitle = dto.VideoTitle;
            value.VideoUrl = dto.VideoUrl;
            value.VideoDescription = dto.VideoDescription;
            value.IsFeature = dto.IsFeature;
            value.FeatureImageUrl = dto.FeatureImageUrl;
            value.AppUserId = dto.AppUserId;
            value.CategoryId = dto.CategoryId;

            _context.SaveChanges();

            return Ok("Trading video güncellendi");
        }

    }
}
