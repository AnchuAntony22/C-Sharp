namespace WebApplicationEF.Models
{
    public class Holder
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public List<string>PurchaseHistory { get; set; }
        public Insurance Insurance { get; set; }


    }
}
