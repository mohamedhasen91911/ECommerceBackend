namespace Backend.DTO.StockHistory
{
    public class StockHistoryCreateDto
    {
    public int Product_ID { get; set; }
    public int Change { get; set; }
    public string Reason { get; set; }
    }

 }