using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class LogInUserDTO
    {
        private string username;
        [Required(ErrorMessage = "Type something bitch")]
        public string Username { get { return username; } set { username = value; } }

        private string password;    
        [Required]
        public string Password { get { return password; } set { password = value; } }

    }
}
