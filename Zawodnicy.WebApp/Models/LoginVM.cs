using System.ComponentModel.DataAnnotations;

namespace Zawodnicy.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Nazwa użytkowanika jest wymagana")]
        [Display(Name ="Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Hasło jest wymagane")]
        [Display(Name ="Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
