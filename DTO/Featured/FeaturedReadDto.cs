namespace Backend.DTO.Featured
{
     public class FeaturedReadDto
    {
        public int Featured_ID { get; set; }
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
    }
 }