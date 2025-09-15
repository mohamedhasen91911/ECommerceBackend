namespace Backend.DTO.Payment
{
    public class PaymentReadDto
    {
        public int Payment_ID { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Method { get; set; }
        public DateTime Payment_Date { get; set; }
        public int Order_ID { get; set; }
     }
 }