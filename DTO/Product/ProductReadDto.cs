namespace Backend.DTO.Product
{
    public class ProductReadDto
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }

        public string MerchantName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }

     }
 }