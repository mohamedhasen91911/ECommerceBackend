namespace Backend.DTO.Featured
{
     public class FeaturedCreateDto
    {
        public int Product_ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
    }

 }