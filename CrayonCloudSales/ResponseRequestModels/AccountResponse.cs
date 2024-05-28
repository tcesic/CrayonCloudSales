using DataAccess.Entities;

namespace CrayonCloudSales.ResponseRequestModels
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CustomerName { get; set; }
    }
}
