using System.ComponentModel.DataAnnotations;

namespace E_commrec.ViewModel
{
    public class RegisterAccountviewmodel
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        [Compare("Password", ErrorMessage ="Password and Confirm not mated")]
        public string ConfirmPassword { get; set; }
        

       




    }
}
