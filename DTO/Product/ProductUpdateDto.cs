namespace Backend.DTO.Product
{
    public class ProductUpdateDto
    {
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Category_ID { get; set; }
        public int Brand_ID { get; set; }
     }
 }