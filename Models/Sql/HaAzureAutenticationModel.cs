namespace ExrtractAzure
{
    public class HaAzureAutenticationModel
    {
        public HaAzureAutenticationModel(string clientId, string clientSecret, string tenantId)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string TenantId { get; set; }

    }
}