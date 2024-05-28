namespace DataAccess.Entities
{
    public class Software
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? State { get; set; }
        public DateTime ValidTo { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}