using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace ExrtractAzure
{
    public class HaISqlVirtualNetworkRule
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
        //     Gets the subnet ID of the Azure SQL Server Virtual Network Rule.
        public string SubnetId { get; set; }
        //
        // Summary:
        //     Gets name of the SQL Server to which this Virtual Network Rule belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets the Azure SQL Server Virtual Network Rule state; possible values include:
        //     'Initializing', 'InProgress', 'Ready', 'Deleting', 'Unknown'.
        public string State { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }
    }
}