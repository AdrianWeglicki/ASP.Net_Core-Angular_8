using System.ComponentModel.DataAnnotations;

namespace DatingSite.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage="Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }
        [Required(ErrorMessage="Hasło jest wymagane")]
        [StringLength(12, MinimumLength=6, ErrorMessage="Hasło musi się składać od 4 do 8 znakow")]
        public string Password { get; set; } 
    }
}