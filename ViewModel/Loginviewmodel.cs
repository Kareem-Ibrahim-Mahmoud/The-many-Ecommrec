using System.ComponentModel.DataAnnotations;

namespace E_commrec.ViewModel
{
    public class Loginviewmodel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        public bool preseste { get; set; }

    }
}
