
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.Sql.Fluent;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;





namespace ExrtractAzure
{

    class Program
    {


        static void Main(string[] args)
        {
            //var location = Region.EuropeWest;

            string json = File.ReadAllText("azureauth.properties");
            Credentials localCredentials = JsonConvert.DeserializeObject<Credentials>(json);

            HaAzureAutenticationModel autenticationModel = new HaAzureAutenticationModel(localCredentials.clientId, localCredentials.clientSecret, localCredentials.tenantId);
            AzureCredentials credentials = HaAzureAuthentication.GetAzCredentials(autenticationModel);
            IAzure azure = HaAzureAuthentication.GetAzManagementClient(credentials);

            //SystemAssignedManagedServiceIdentityTenantId
            //Version
            //ISqlServerKeyActionsDefinition ServerKeys
            //SystemAssignedManagedServiceIdentityPrincipalId
            //IdentityType ManagedServiceIdentityType
            //ISqlElasticPoolActionsDefinition ElasticPools
            //Kind
            //FullyQualifiedDomainName
            //ISqlServerDnsAliasActionsDefinition DnsAliases
            //ISqlDatabaseActionsDefinition Databases
            //ISqlFailoverGroupActionsDefinition FailoverGroups
            //ISqlEncryptionProtectorActionsDefinition EncryptionProtectors
            //IsManagedServiceIdentityEnabled
            //ISqlVirtualNetworkRuleActionsDefinition VirtualNetworkRules
            //ISqlFirewallRuleActionsDefinition FirewallRules
            //AdministratorLogin
            //State


            String jsonString = null;
            List<HaISqlServerModel> sqlServerModels = new List<HaISqlServerModel>();

            foreach (var sqlServer in azure.SqlServers.List())
            {

                HaISqlServerModel objSqlServer = LoadSqlServerCoreProperties(azure, sqlServer);

                //LoadSqlServerKeys(azure, sqlServer, objSqlServer);

                //LoadElasticPools(azure, sqlServer, objSqlServer);

                //LoadDnsAliases(azure, sqlServer, objSqlServer);

                //LoadSqlDatabases(azure, sqlServer, objSqlServer);

                //LoadSqlFailoverGroups(azure, sqlServer, objSqlServer);

                LoadSqlEncryptionProtectors(azure, sqlServer, objSqlServer);

                LoadSqlVirtualNetworkRules(azure, sqlServer, objSqlServer);

                LoadSqlFirewallRules(azure, sqlServer, objSqlServer);

                sqlServerModels.Add(objSqlServer);

            }

            //jsonString += JsonConvert.SerializeObject(sqlServerModels, Formatting.Indented);
            //Console.WriteLine(jsonString);
        }

        private static HaISqlServerModel LoadSqlServerCoreProperties(IAzure azure, ISqlServer sqlServer)
        {
            var myObject = new HaISqlServerModel();

            string myId = sqlServer.Id;

            //Id, Type, Name, ResourceGroupName, SubscriptionId, Region, RegionName, Type

            myObject.Id = myId;
            myObject.Type = azure.GenericResources.GetById(myId).Type;
            myObject.Name = azure.GenericResources.GetById(myId).Name;
            myObject.ResourceGroupName = azure.GenericResources.GetById(myId).ResourceGroupName;
            myObject.SubscriptionId = azure.GenericResources.GetById(myId).Id.Split('/')[2];
            myObject.Region = azure.GenericResources.GetById(myId).Region;
            myObject.RegionName = azure.GenericResources.GetById(myId).RegionName;
            myObject.Tags = azure.GenericResources.GetById(myId).Tags;
            //Type, Id



            //Specifics
            myObject.Version = sqlServer.Version;
            myObject.SystemAssignedManagedServiceIdentityPrincipalId = sqlServer.SystemAssignedManagedServiceIdentityPrincipalId;
            myObject.SystemAssignedManagedServiceIdentityTenantId = sqlServer.SystemAssignedManagedServiceIdentityTenantId;
            myObject.Kind = sqlServer.Kind;
            myObject.FullyQualifiedDomainName = sqlServer.FullyQualifiedDomainName;
            myObject.IsManagedServiceIdentityEnabled = sqlServer.IsManagedServiceIdentityEnabled;
            myObject.AdministratorLogin = sqlServer.AdministratorLogin;
            myObject.State = sqlServer.State;
            myObject.ManagedServiceIdentityType = sqlServer.ManagedServiceIdentityType;
            return myObject;
        }

        private static void LoadSqlFirewallRules(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            // firewallRules cannot be referenced by GenericResource.Id 

            List<HaISqlFirewallRule> objSqlFirewallRules = new List<HaISqlFirewallRule>();

            foreach (var firewallRule in sqlServer.FirewallRules.List())
            {



                

                objSqlFirewallRules.Add(new HaISqlFirewallRule()
                {
                    //Id, Type, Name, ResourceGroupName, SubscriptionId, Region, RegionName, Type

                    Name = firewallRule.Name,
                    ResourceGroupName=firewallRule.ResourceGroupName,
                    SubscriptionId=firewallRule.Id.Split('/')[2],
                    Region=firewallRule.Region,
                    //Type, Id
                    Type = "firewallRules",
                    Id = firewallRule.Id,
                    //Specifics
                    Kind = firewallRule.Kind,
                    StartIPAddress = firewallRule.StartIPAddress,
                    EndIPAddress = firewallRule.EndIPAddress,
                    ParentId =firewallRule.ParentId,
                    SqlServerName = firewallRule.SqlServerName
                }
                );


            }
            objSqlServer.sqlFirewallRules = objSqlFirewallRules;
        }

        private static void LoadSqlVirtualNetworkRules(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var virtualNetworkRules in sqlServer.VirtualNetworkRules.List())
            {
                // Unsure if this can be referenced by GenericResource.Id 

                Console.WriteLine(azure.GenericResources.GetById(virtualNetworkRules.Id).Type);

                List<HaISqlVirtualNetworkRule> objSqlVirtualNetworkRules = new List<HaISqlVirtualNetworkRule>();

                objSqlVirtualNetworkRules.Add(new HaISqlVirtualNetworkRule()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName 
                    Name = virtualNetworkRules.Name,
                    ResourceGroupName = virtualNetworkRules.ResourceGroupName,
                    SubscriptionId = virtualNetworkRules.Id.Split('/')[2],
                    // No Region
                    // No RegionName
                    //Type, Id
                    Type = "SqlVirtualNetworkRule",
                    Id = virtualNetworkRules.Id,
                    //Specifics
                    SubnetId = virtualNetworkRules.SubnetId,
                    State = virtualNetworkRules.State,
                    SqlServerName = virtualNetworkRules.SqlServerName,
                    ParentId = virtualNetworkRules.ParentId

                }
                );


                objSqlServer.sqlVirtualNetworkRules = objSqlVirtualNetworkRules;
            }
        }

        private static void LoadSqlEncryptionProtectors(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            string strRegionName;

            foreach (var encryptionProtector in sqlServer.EncryptionProtectors.List())
            {
                // Microsoft.Sql/servers/encryptionProtector can be referenced by GenericResource.Id 

                Console.WriteLine(azure.GenericResources.GetById(encryptionProtector.Id).Type);


                List<HaISqlEncryptionProtectorModel> objSqlEncryptionProtectors = new List<HaISqlEncryptionProtectorModel>();

                objSqlEncryptionProtectors.Add(new HaISqlEncryptionProtectorModel()
                {
                    ////Name, ResourceGroupName, SubscriptionId, Region, RegionName 
                    ////No name
                    ResourceGroupName = encryptionProtector.ResourceGroupName,
                    SubscriptionId = encryptionProtector.Id.Split('/')[2],
                    Region = encryptionProtector.Inner.Subregion,
                    ////Type, Id
                    Type = "SqlEncryptionProtector",
                    Id = encryptionProtector.Id,
                    ////Specifics
                    Kind = encryptionProtector.Kind,
                    ServerKeyName = encryptionProtector.ServerKeyName,
                    ServerKeyType = encryptionProtector.ServerKeyType,
                    Thumbprint = encryptionProtector.Thumbprint,
                    Uri = encryptionProtector.Uri,
                    SqlServerName = encryptionProtector.SqlServerName,
                    ParentId = encryptionProtector.ParentId

                }
                );


                objSqlServer.sqlEncryptionProtectors = objSqlEncryptionProtectors;
            }
        }

        private static void LoadSqlFailoverGroups(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var failoverGroup in sqlServer.FailoverGroups.List())
            {
                // Unsure if this can be referenced by GenericResource.Id 

                Console.WriteLine(azure.GenericResources.GetById(failoverGroup.Id).Type);

                List<HaISqlFailoverGroup> objSqlFailoverGroups = new List<HaISqlFailoverGroup>();

                objSqlFailoverGroups.Add(new HaISqlFailoverGroup()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName 
                    Name = failoverGroup.Name,
                    RegionName = failoverGroup.Name,
                    ResourceGroupName = failoverGroup.ResourceGroupName,
                    SubscriptionId = failoverGroup.Id.Split('/')[2],
                    Region=failoverGroup.Region,
                    
                    //Type, Id
                    Type = "SqlFailoverGroup",
                    Id = failoverGroup.Id,
                    //Specifics
                    Databases = failoverGroup.Databases,
                    PartnerServers = failoverGroup.PartnerServers,
                    ReadOnlyEndpointPolicy = failoverGroup.ReadOnlyEndpointPolicy,
                    //Need read / write
                    //ReadWriteEndpointPolicy = failoverGroup.ReadWriteEndpointPolicy,
                    ReadWriteEndpointDataLossGracePeriodMinutes = failoverGroup.ReadWriteEndpointDataLossGracePeriodMinutes,
                    //Need read / write
                    //ReplicationRole = failoverGroup.ReplicationRole,
                    ReplicationState = failoverGroup.ReplicationState,
                    SqlServerName = failoverGroup.SqlServerName,
                    ParentId = failoverGroup.ParentId


                }
                );

                objSqlServer.sqlFailoverGroups = objSqlFailoverGroups;
            }
        }

        private static void LoadSqlDatabases(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            List<HaISqlDatabase> objSqlDatabase = new List<HaISqlDatabase>();

            
            foreach (var sqlDatabase in sqlServer.Databases.List())
            {

                // Microsoft.Sql/servers/databases can be referenced by GenericResource.Id 

                Console.WriteLine(azure.GenericResources.GetById(sqlDatabase.Id).Type);

                string myId = sqlDatabase.Id;

                objSqlDatabase.Add(new HaISqlDatabase()
                {

                    //Name = azure.GenericResources.GetById(elasticPool.Id).Name,
                    //ResourceGroupName = azure.GenericResources.GetById(elasticPool.Id).ResourceGroupName,
                    //SubscriptionId = azure.GenericResources.GetById(elasticPool.Id).Id.Split('/')[2],
                    //Region = azure.GenericResources.GetById(elasticPool.Id).Region,
                    //RegionName = azure.GenericResources.GetById(elasticPool.Id).RegionName,
                    //Type = azure.GenericResources.GetById(elasticPool.Id).Type,

                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName 
                    Name = azure.GenericResources.GetById(sqlDatabase.Id).Name,
                    ResourceGroupName = azure.GenericResources.GetById(sqlDatabase.Id).ResourceGroupName,
                    SubscriptionId = sqlDatabase.Id.Split('/')[2],
                    Region = azure.GenericResources.GetById(sqlDatabase.Id).Region,
                    RegionName = azure.GenericResources.GetById(sqlDatabase.Id).RegionName,
                    //Type, Id
                    Type = azure.GenericResources.GetById(sqlDatabase.Id).Type,
                    Id = sqlDatabase.Id,
                    //Specifics
                    Collation=sqlDatabase.Collation,
                    CreationDate = sqlDatabase.CreationDate,
                    CurrentServiceObjectiveId = sqlDatabase.CurrentServiceObjectiveId,
                    DatabaseId = sqlDatabase.DatabaseId,
                    DefaultSecondaryLocation = sqlDatabase.DefaultSecondaryLocation,
                    EarliestRestoreDate = sqlDatabase.EarliestRestoreDate,
                    Edition = sqlDatabase.Edition,
                    ElasticPoolName = sqlDatabase.ElasticPoolName,
                    IsDataWarehouse = sqlDatabase.IsDataWarehouse,
                    MaxSizeBytes = sqlDatabase.MaxSizeBytes,
                    RequestedServiceObjectiveId = sqlDatabase.RequestedServiceObjectiveId,
                    RequestedServiceObjectiveName = sqlDatabase.RequestedServiceObjectiveName,
                    ServiceLevelObjective = sqlDatabase.ServiceLevelObjective,
                    Status = sqlDatabase.Status,
                    SyncGroups = sqlDatabase.SyncGroups,
                    Tags = azure.GenericResources.GetById(sqlDatabase.Id).Tags,
                    ParentId =sqlDatabase.ParentId,
                    SqlServerName=sqlDatabase.SqlServerName
                }
                );

            }
            objSqlServer.sqlDatabases = objSqlDatabase;
        }

        private static void LoadDnsAliases(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            List<HaISqlServerDnsAlias> objSqlDnsAlias = new List<HaISqlServerDnsAlias>();
            foreach (var dnsAlias in sqlServer.DnsAliases.List())
            {

                // Microsoft.Sql/servers/dnsAliases can be referenced by GenericResource.Id 

                Console.WriteLine(azure.GenericResources.GetById(dnsAlias.Id).Type);

                objSqlDnsAlias.Add(new HaISqlServerDnsAlias()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName 
                    Name = dnsAlias.Name,
                    ResourceGroupName = dnsAlias.ResourceGroupName,
                    SubscriptionId = dnsAlias.Id.Split('/')[2],
                    //Region not implemented
                    //RegionName not implemented
                    //Type, Id
                    Type= azure.GenericResources.GetById(dnsAlias.Id).Type,
                    Id = dnsAlias.Id,
                    //Specifics
                    AzureDnsRecord = dnsAlias.AzureDnsRecord,
                    ParentId = dnsAlias.ParentId,
                    SqlServerName = dnsAlias.SqlServerName

                }
                );

                
            }
            objSqlServer.sqlServerDnsAliases = objSqlDnsAlias;
        }

        private static void LoadElasticPools(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var elasticPool in sqlServer.ElasticPools.List())
            {
                List<HaISqlElasticPool> objSqlElasticPool = new List<HaISqlElasticPool>();

                // Microsoft.Sql/servers/elasticPools can be referenced by GenericResource.Id 


                Console.WriteLine(azure.GenericResources.GetById(elasticPool.Id).Type);




                objSqlElasticPool.Add(new HaISqlElasticPool()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName
                    Name = azure.GenericResources.GetById(elasticPool.Id).Name,
                    ResourceGroupName = azure.GenericResources.GetById(elasticPool.Id).ResourceGroupName,
                    SubscriptionId = azure.GenericResources.GetById(elasticPool.Id).Id.Split('/')[2],
                    Region = azure.GenericResources.GetById(elasticPool.Id).Region,
                    RegionName = azure.GenericResources.GetById(elasticPool.Id).RegionName,
                    Type = azure.GenericResources.GetById(elasticPool.Id).Type,
                    //Type,Id

                    Id = elasticPool.Id,
                    //Specifics
                    DatabaseDtuMin = elasticPool.DatabaseDtuMin,
                    DatabaseDtuMax = elasticPool.DatabaseDtuMax,
                    Edition = elasticPool.Edition,
                    CreationDate = elasticPool.CreationDate,
                    Dtu = elasticPool.Dtu,
                    StorageCapacityInMB = elasticPool.StorageCapacityInMB,
                    StorageMB = elasticPool.StorageMB,
                    State = elasticPool.State,
                    ParentId = elasticPool.ParentId,
                    SqlServerName = elasticPool.SqlServerName

                }
                );

                objSqlServer.sqlServerElasticPool = objSqlElasticPool;
            }
        }

        private static void LoadSqlServerKeys(IAzure azure, ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var svrKey in sqlServer.ServerKeys.List())
            {
                // Microsoft.Sql/servers/keys can be referenced by GenericResource.Id 


                Console.WriteLine(azure.GenericResources.GetById(svrKey.Id).Type);

                //HaISqlServerKey objServerKey = new HaISqlServerKey();
                List<HaISqlServerKey> objSqlServerKey = new List<HaISqlServerKey>();

                objSqlServerKey.Add(new HaISqlServerKey()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName
                    Name = svrKey.Name,
                    Region = svrKey.Region,
                    ResourceGroupName = svrKey.ResourceGroupName,
                    SubscriptionId = svrKey.Id.Split('/')[2],
                    //Type,Id
                    Type = "sqlServerKey",
                    Id = svrKey.Id,
                    ServerKeyType = svrKey.ServerKeyType,
                    //Specifics
                    SqlServerName = svrKey.SqlServerName,
                    CreationDate = svrKey.CreationDate,
                    Kind = svrKey.Kind,
                    ParentId = svrKey.ParentId,
                    Thumbprint = svrKey.Thumbprint,
                    Uri = svrKey.Uri

                }
                );


                objSqlServer.sqlServerKeys = objSqlServerKey;


            }
        }
    }
}
