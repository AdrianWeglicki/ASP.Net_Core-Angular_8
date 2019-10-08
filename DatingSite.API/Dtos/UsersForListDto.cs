using System;

namespace DatingSite.API.Dtos
{
    public class UsersForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Country { get; set; }   
        public string PhotoUrl { get; set; }
    }
}