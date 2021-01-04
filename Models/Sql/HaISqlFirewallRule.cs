using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Collections.Generic;

namespace ExrtractAzure
{
    public class HaISqlFirewallRule
    {
        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string SubscriptionId { get; set; }

        public Region Region { get; set; }

        public string RegionName { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        public IReadOnlyDictionary<string, string> Tags { get; set; }

        //
        // Summary:
        //     Gets name of the SQL Server to which this Firewall Rule belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets kind of SQL Server that contains this Firewall Rule.
        public string Kind { get; set; }
        //
        // Summary:
        //     Gets the start IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        public string StartIPAddress { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }
        //
        // Summary:
        //     Gets the end IP address (in IPv4 format) of the Azure SQL Server Firewall Rule.
        public string EndIPAddress { get; set; }
    }
}