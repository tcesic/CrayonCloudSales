namespace CrayonCloudSales.Services.CcpService
{

    public interface ICcpService
    {
        Task<IEnumerable<Service>> GetAvailableServicesAsync();
        Task<Service> OrderServiceAsync(int serviceId, int quantity);
    }


    public class CcpService : ICcpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _ccpServiceBaseUrl;

        public CcpService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _ccpServiceBaseUrl = configuration.GetValue<string>("CcpServiceBaseUrl");
        }

        public async Task<IEnumerable<Service>> GetAvailableServicesAsync()
        {
            var services = await _httpClient.GetFromJsonAsync<IEnumerable<Service>>($"{_ccpServiceBaseUrl}/api/services");
            return services!;
        }

        public async Task<Service> OrderServiceAsync(int serviceId, int quantity)
        {
            var request = new OrderRequest { ServiceId = serviceId, Quantity = quantity };
            var response = await _httpClient.PostAsJsonAsync($"{_ccpServiceBaseUrl}/api/services/order", request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Service>();
            return result!;
        }
    }
}
