namespace CrayonCloudSales.ResponseRequestModels
{
    public class SoftwareResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? State { get; set; }
        public string? ValidTo { get; set; }
    }
}
