using System.ComponentModel.DataAnnotations;

namespace DatingSite.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage="Nazwa uzytkownika jest wymagana")]
        public string Username { get; set; }
        [Required(ErrorMessage="Haslo jest wymagane")]
        [StringLength(12, MinimumLength=6, ErrorMessage="Haslo musi się skladac od 4 do 12 znakow")]
        public string Password { get; set; } 
    }
}