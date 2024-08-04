using System.ComponentModel.DataAnnotations;

namespace E_commrec.Models
{
    public class Prouduct
    {
        public int Id { get; set; }
        [MaxLength(10,ErrorMessage ="mail most be leth than 10 char")]
        [Required]
        public string Name { get; set; }

        public string Image { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }


    }
}
