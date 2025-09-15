namespace Backend.DTO.Payment
{
    public class PaymentCreateDto
    {
        public int Order_ID { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Method { get; set; }
     }
 }