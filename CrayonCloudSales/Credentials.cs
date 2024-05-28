namespace CrayonCloudSales
{
    public static class Credentials
    {
        //This username and password are kind of database users simualiton just mocked to this one user for this purpose
        public const string Username = "api_user";
        public const string Password = "api_password";

        //Better than appsettings.json, but for production some of Secrets Manager Services like AWS Secret Manager or Azure Key Vault,..
        public const string SecretKey = "vPH5TqC8bGfyQh2LM7D5t1F6yE8nC6QrJ6zW/7J2G5U=,";
    }
}
