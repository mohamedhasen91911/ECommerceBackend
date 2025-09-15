
namespace Backend.DTO.Order
{
    public class OrderListDto
    {
        public int Order_ID { get; set; }
        public DateTime Order_Date { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
     }
 }