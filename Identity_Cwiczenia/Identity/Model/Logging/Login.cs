using System.ComponentModel.DataAnnotations;

namespace IDENTITY_Cwiczenia.Identity.Model.Logging
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool Remember { get; set; }
    }
}
