using AutoMapper;
using BtkAkademiAi.WebApi.Context;
using BtkAkademiAi.WebApi.Dtos.ArticleDtos;
using BtkAkademiAi.WebApi.Dtos.CommentDto;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademiAi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        public class CommentsController : ControllerBase
        {
            private readonly BlogAIContext _context;
            private readonly IMapper _mapper;
            public CommentsController(BlogAIContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult CommentList()
            {
            var comments = _context.Comments.Include(x => x.AppUser).Include(x => x.Article).ToList();
            var commentDtos = _mapper.Map<List<ResultCommentDto>>(comments);
            return Ok(commentDtos);
        }
            [HttpPost]
            public IActionResult CreateComment(CreateCommentDto createCommentDto)
            {
                var Comment = _mapper.Map<Comment>(createCommentDto);
                _context.Comments.Add(Comment);
                _context.SaveChanges();
                return Ok("Yorum ekleme başarılı");


            }
            [HttpDelete]
            public IActionResult DeleteComment(int id)
            {
                var Comment = _context.Comments.Find(id);
                if (Comment == null)
                {
                    return NotFound("Yorum bulunamadı");
                }
                _context.Comments.Remove(Comment);
                _context.SaveChanges();
                return Ok("Yorum silme başarılı");
            }
            [HttpGet("ID")]
            public IActionResult GetComment(int id)
            {
               var comment = _context.Comments.Include(x => x.AppUser).Include(x => x.Article).FirstOrDefault(x => x.CommentId == id);
                if (comment == null)
                {
                    return NotFound("Yorum bulunamadı");
                }
                var commentDto = _mapper.Map<ResultCommentDto>(comment);
                return Ok(commentDto);
        }

            [HttpPut]
            public IActionResult UpdateComment(UpdateCommentDto updateCommentDto)
            {
            var comment = _mapper.Map<Comment>(updateCommentDto);
            _context.Comments.Update(comment);
            _context.SaveChanges();
            return Ok("Yorum güncelleme başarılı");

        }

        }
    }
