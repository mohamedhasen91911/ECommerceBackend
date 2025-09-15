namespace Backend.DTO.Review
{
    public class ReviewCreateDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int Customer_ID { get; set; }
        public int Product_ID { get; set; }
     }
 }