using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace ExrtractAzure
{
    class HaAzureAuthentication
    {
        public static IAzure GetAzManagementClient(AzureCredentials credentials)
        {
            return Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithDefaultSubscription();
        }

        public static AzureCredentials GetAzCredentials(string clientId, string clientSecret, string tenantId)
        {
            return SdkContext.AzureCredentialsFactory
              .FromServicePrincipal(clientId, clientSecret, tenantId, AzureEnvironment.AzureGlobalCloud);
        }

        public static AzureCredentials GetAzCredentials(HaAzureAutenticationModel autenticationModel)
        {
            return SdkContext.AzureCredentialsFactory
              .FromServicePrincipal(autenticationModel.ClientId,autenticationModel.ClientSecret,autenticationModel.TenantId, AzureEnvironment.AzureGlobalCloud);
        }
    }
}