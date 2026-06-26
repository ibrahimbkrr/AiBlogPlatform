using BtkAkademiAi.WebApi.Entities;

namespace BtkAkademiAi.WebApi.Dtos.CommentDto
{
    public class CreateCommentDto
    {
                
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public bool IsConfirm { get; set; }

        public string CommentStatus { get; set; }

        public string AppUserId { get; set; }

        public int ArticleId { get; set; }

        public decimal Rating { get; set; }


    }
}
