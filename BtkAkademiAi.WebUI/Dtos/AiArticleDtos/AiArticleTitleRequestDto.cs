using System.ComponentModel.DataAnnotations;

namespace BtkAkademiAi.WebUI.Dtos.AiArticleDtos
{
    public class AiArticleTitleRequestDto
    {
        [Required(ErrorMessage = "Lütfen başlık üretilecek metni giriniz.")]
        [MinLength(10, ErrorMessage = "En az 10 karakter giriniz.")]
        [MaxLength(3000, ErrorMessage = "En fazla 3000 karakter girebilirsiniz.")]
        public string ArticleText { get; set; } = string.Empty;
    }
}
