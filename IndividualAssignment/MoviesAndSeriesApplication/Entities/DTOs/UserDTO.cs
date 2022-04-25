using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class UserDTO
    {
        private string username;
        [Required]
        public string Username{ get { return username; } set { username = value; } }

        private string name;
        [Required]
        public string Name { get { return name; } set { name = value; } }

        private string email;
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="The input is not valid")]
        public string Email { get { return email; } set { email = value; } }

        private string number;
        [Required]
        public string PhoneNumber { get { return number; } set { number = value; } }

        private string password;
        [Required]
        [MinLength(6, ErrorMessage = "The minimum lenth of the password is 6 characters")]
        public string Password { get { return password; } set { password = value; } }

        private string confirmPass;
        [Required]
        public string ConfirmPass { get { return confirmPass; } set { confirmPass = value; } }
    }
}
