using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IDENTITY_Cwiczenia.Identity.Models
{
    [BindProperties(SupportsGet = true)]
    public class UserData
    {
        [Required]
        public string Name { get; set; }
        
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
           ErrorMessage = "E-mail is not valid")]
		[Required]
		public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
 