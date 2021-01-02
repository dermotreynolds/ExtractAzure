
using Microsoft.Azure.Management.Fluent;
//using AutoMapper;
//using System.Dynamic;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.Sql.Fluent;
using Newtonsoft.Json;
//using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.Models;
//using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition;
//using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition;

using System;
using System.IO;
using System.Linq;

//using Microsoft.Azure.Commands.Common.Authentication;
//using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
//using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
//using Microsoft.Azure.Commands.Sql.Server.Model;
//using Microsoft.WindowsAzure.Commands.Common;
//using System.Collections.Generic;
//using System.IO;
//using System.Management.Automation;
//using System.Reflection;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;




namespace ExrtractAzure
{

    class Program
    {


        static void Main(string[] args)
        {
            //var location = Region.EuropeWest;

            args

            HaAzureAutenticationModel autenticationModel = new HaAzureAutenticationModel(clientId, clientSecret, tenantId);
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


            //#Quick Activity Log Test###################################################
            DateTime recordDateTime = DateTime.Now;
            // get activity logs for the same period.
            var logs = azure.ActivityLogs.DefineQuery()
                    .StartingFrom(recordDateTime.AddDays(-7))
                    .EndsBefore(recordDateTime)
                    .WithAllPropertiesInResponse()
                    .FilterByResource("/subscriptions/bc0b3b15-7d6c-4fa4-b3a7-d208b08fde5c/resourceGroups/DELETE/providers/Microsoft.Sql/servers/testtestdr01")
                    .Execute();

            Console.WriteLine("Activity logs for the Storage Account:");

            foreach (var eventData in logs)
            {

                //Console.WriteLine("\tDateTime: " + eventData.EventTimestamp);
                //Console.WriteLine("\tEvent: " + eventData.EventName?.LocalizedValue);
                //Console.WriteLine("\tOperation: " + eventData.OperationName?.LocalizedValue);
                //Console.WriteLine("\tCaller: " + eventData.Caller);
                //Console.WriteLine("\tCorrelationId: " + eventData.CorrelationId);
                //Console.WriteLine("\tSubscriptionId: " + eventData.SubscriptionId);

                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", eventData.EventTimestamp, eventData.EventName?.LocalizedValue, eventData.Caller, eventData.CorrelationId, eventData.SubscriptionId, eventData.OperationName?.LocalizedValue);
                //console.writeline("\tevent: " + eventdata.eventname?.localizedvalue);
                //console.writeline("\toperation: " + eventdata.operationname?.localizedvalue);
                //console.writeline("\tcaller: " + eventdata.caller);
                //console.writeline("\tcorrelationid: " + eventdata.correlationid);
                //console.writeline("\tsubscriptionid: " + eventdata.subscriptionid);
            }


            //#Quick Activity Log Test###################################################

            //#Quick Network Watcher Test#######################

            

            //#Quick Network Watcher Test#######################










            foreach (var sqlServer in azure.SqlServers.List())
            {

                //HaISqlServerModel objSqlServer = LoadSqlServerCoreProperties(sqlServer);

                //LoadSqlServerKeys(sqlServer, objSqlServer);

                //LoadElasticPools(azure, sqlServer, objSqlServer);

                //LoadDnsAliases(azure, sqlServer, objSqlServer);

                //LoadSqlDatabases(azure, sqlServer, objSqlServer);

                //LoadSqlFailoverGroups(sqlServer, objSqlServer);

                //LoadSqlEncryptionProtectors(sqlServer, objSqlServer);

                //LoadSqlVirtualNetworkRules(sqlServer, objSqlServer);

                //LoadSqlFirewallRules(sqlServer, objSqlServer);

                //sqlServerModels.Add(objSqlServer);

            }

            //jsonString += JsonConvert.SerializeObject(sqlServerModels, Formatting.Indented);
            //Console.WriteLine(jsonString);
        }

        private static HaISqlServerModel LoadSqlServerCoreProperties(ISqlServer sqlServer)
        {
            var objSqlServer = new HaISqlServerModel();

            //Name, ResourceGroupName, SubscriptionId, Region, RegionName 
            objSqlServer.Name = sqlServer.Name;

            objSqlServer.ResourceGroupName = sqlServer.ResourceGroupName;
            objSqlServer.SubscriptionId = sqlServer.Id.Split('/')[2];
            objSqlServer.Region = sqlServer.Region;
            objSqlServer.RegionName = sqlServer.Region.Name;

            //Type, Id
            objSqlServer.Type = sqlServer.Type;
            objSqlServer.Id = sqlServer.Id;

            //Specifics
            objSqlServer.Version = sqlServer.Version;
            objSqlServer.SystemAssignedManagedServiceIdentityPrincipalId = sqlServer.SystemAssignedManagedServiceIdentityPrincipalId;
            objSqlServer.SystemAssignedManagedServiceIdentityTenantId = sqlServer.SystemAssignedManagedServiceIdentityTenantId;
            objSqlServer.Kind = sqlServer.Kind;
            objSqlServer.FullyQualifiedDomainName = sqlServer.FullyQualifiedDomainName;
            objSqlServer.IsManagedServiceIdentityEnabled = sqlServer.IsManagedServiceIdentityEnabled;
            objSqlServer.AdministratorLogin = sqlServer.AdministratorLogin;
            objSqlServer.State = sqlServer.State;
            objSqlServer.ManagedServiceIdentityType = sqlServer.ManagedServiceIdentityType;
            return objSqlServer;
        }

        private static void LoadSqlFirewallRules(ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {

            List<HaISqlFirewallRule> objSqlFirewallRules = new List<HaISqlFirewallRule>();

            foreach (var firewallRule in sqlServer.FirewallRules.List())
            {




                objSqlFirewallRules.Add(new HaISqlFirewallRule()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName 
                    Name = firewallRule.Name,
                    ResourceGroupName=firewallRule.ResourceGroupName,
                    SubscriptionId=firewallRule.Id.Split('/')[2],
                    Region=firewallRule.Region,
                    //Type, Id
                    Type = "SqlFirewallRule",
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

        private static void LoadSqlVirtualNetworkRules(ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var virtualNetworkRules in sqlServer.VirtualNetworkRules.List())
            {
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

        private static void LoadSqlEncryptionProtectors(ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            string strRegionName;

            foreach (var encryptionProtector in sqlServer.EncryptionProtectors.List())
            {

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

        private static void LoadSqlFailoverGroups(ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var failoverGroup in sqlServer.FailoverGroups.List())
            {
                //TODO
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
                
                objSqlDatabase.Add(new HaISqlDatabase()
                {
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

                //string strRegionName = null;

                //if (elasticPool.Region != null)
                //{
                //    strRegionName = elasticPool.Region.Name;
                //}
                //else
                //{
                //    strRegionName = null;
                //}

                objSqlElasticPool.Add(new HaISqlElasticPool()
                {
                    //Name, ResourceGroupName, SubscriptionId, Region, RegionName
                    Name = azure.GenericResources.GetById(elasticPool.Id).Name,
                    ResourceGroupName = azure.GenericResources.GetById(elasticPool.Id).ResourceGroupName,
                    SubscriptionId = elasticPool.Id.Split('/')[2],
                    Region = azure.GenericResources.GetById(elasticPool.Id).Region,
                    RegionName = azure.GenericResources.GetById(elasticPool.Id).RegionName,
                    //Type,Id
                    Type = azure.GenericResources.GetById(elasticPool.Id).Type,
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

        private static void LoadSqlServerKeys(ISqlServer sqlServer, HaISqlServerModel objSqlServer)
        {
            foreach (var svrKey in sqlServer.ServerKeys.List())
            {
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
