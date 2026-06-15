using System.ComponentModel.DataAnnotations;

namespace BtkAkademiAi.WebUI.Dtos.AiArticleDtos
{
    public class AiArticleRequestDto
    {
        [Required(ErrorMessage = "Lütfen makale konusu giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter giriniz.")]
        [MaxLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz.")]
        public string Prompt { get; set; } = string.Empty;
    }
}
