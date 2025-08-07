using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOs.Auth
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Password { get; set; }
        public string idRol { get; set; }
        public string idEnterprice { get; set; }
        [MaxLength(11)]
        public string document { get; set; }
        
    }
}
