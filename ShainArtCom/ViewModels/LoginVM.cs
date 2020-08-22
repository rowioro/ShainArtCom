using System.ComponentModel.DataAnnotations;

namespace ShainArtCom.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
