namespace Backend.DTO.Review
{
    public class ReviewReadDto
    {
        public int Review_ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Review_Date { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
     }
 }