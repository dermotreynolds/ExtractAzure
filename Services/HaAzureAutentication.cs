using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ExrtractAzure
{
    class HaAzureAuthentication
    {
        public static IAzure GetAzManagementClient(AzureCredentials credentials)
        {
            
            return Azure.Configure().WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic).Authenticate(credentials).WithDefaultSubscription();
        }

        public static AzureCredentials GetAzCredentials(string clientId, string clientSecret, string tenantId)
        {
            return SdkContext.AzureCredentialsFactory
              .FromServicePrincipal(clientId, clientSecret, tenantId, AzureEnvironment.AzureGlobalCloud);
        }

        public static AzureCredentials GetAzCredentials(HaAzureAutenticationModel autenticationModel)
        {
            return SdkContext.AzureCredentialsFactory
              .FromServicePrincipal(autenticationModel.ClientId, autenticationModel.ClientSecret, autenticationModel.TenantId, AzureEnvironment.AzureGlobalCloud);
        }
        public void LoadCredentials()
        {
            using (StreamReader r = new StreamReader("azureauth.properties"))
            {
                string json = r.ReadToEnd();
                List<Credentials> items = JsonConvert.DeserializeObject<List<Credentials>>(json);
            }
        }


    }

    public class Credentials
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string tenantId { get; set; }
    }
}