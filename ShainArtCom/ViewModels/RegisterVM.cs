using System.ComponentModel.DataAnnotations;

namespace ShainArtCom.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password requires 8 signs (digit-, uppercase-, lowercase-, special charakter)")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }
    }
}
