namespace E_commrec.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public Order Orders { get; set; }
        public DateTime shipped { get; set; }
    }
}
