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
using System;



namespace ExrtractAzure
{
    class HaISqlServerDnsAlias : IEquatable<HaISqlServerDnsAlias>
    {

        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string SubscriptionId { get; set; }

        // public Region Region { get; set; }

        // public string RegionName { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        //
        // Summary:
        //     Gets name of the SQL Server to which this DNS alias belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets the fully qualified DNS record for alias.
        public string AzureDnsRecord { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }

        public bool Equals(HaISqlServerDnsAlias other)
        {
            if (other == null) return false;
            HaISqlServerDnsAlias objAsPart = other as HaISqlServerDnsAlias;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
    }
}
