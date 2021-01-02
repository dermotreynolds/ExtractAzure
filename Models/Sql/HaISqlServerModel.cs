using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

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
using Microsoft.Azure.Management.Sql.Fluent.Models;



namespace ExrtractAzure
{
    class HaISqlServerModel
    {
        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string SubscriptionId { get; set; }

        public Region Region { get; set; }

        public string RegionName { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        public string Version { get; set; }

        public string SystemAssignedManagedServiceIdentityPrincipalId { get; set; }

        public string SystemAssignedManagedServiceIdentityTenantId { get; set; }

        public string Kind { get; set; }

        public string FullyQualifiedDomainName { get; set; }

        public bool IsManagedServiceIdentityEnabled { get; set; }

        public string AdministratorLogin { get; set; }

        public string State { get; set; }

        //public HaISqlServerKey sqlServerKey { get; set; }

        public List<HaISqlServerKey> sqlServerKeys { get; set; }

        public IdentityType ManagedServiceIdentityType { get; set; }

        public List<HaISqlElasticPool> sqlServerElasticPool { get; set; }

        public List<HaISqlServerDnsAlias> sqlServerDnsAliases {get; set;}

        public List<HaISqlDatabase> sqlDatabases { get; set; }

        public List<HaISqlFailoverGroup> sqlFailoverGroups { get; set; }

        public List<HaISqlEncryptionProtectorModel> sqlEncryptionProtectors { get; set; }

        public List<HaISqlVirtualNetworkRule> sqlVirtualNetworkRules { get; set; }

        public List<HaISqlFirewallRule> sqlFirewallRules { get; set; }


    }
}
