namespace Backend.DTO.StockHistory
{
        public class StockHistoryReadDto
    {
        public int StockHistory_ID { get; set; }
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public int Change { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }

 }