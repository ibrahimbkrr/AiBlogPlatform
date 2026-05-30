using Microsoft.AspNetCore.Identity;

namespace BtkAkademiAi.WebApi.Entities
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Decscription { get; set; }
        public string ImageUrl { get; set; }

        public List<Article> Articles { get; set; }
    }
}
