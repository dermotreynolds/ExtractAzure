
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

using System;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace ExrtractAzure
{
    class HaISqlFailoverGroup // : IEquatable<HaISqlFailoverGroup>
    {
        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string SubscriptionId { get; set; }

        public Region Region { get; set; }

        public string RegionName { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }
        //
        // Summary:
        //     Gets the failover policy of the read-write endpoint for the failover group.
        public ReadWriteEndpointFailoverPolicy ReadWriteEndpointPolicy { get; }
        //
        // Summary:
        //     Gets the local replication role of the failover group instance.
        public FailoverGroupReplicationRole ReplicationRole { get; }
        //
        // Summary:
        //     Gets the replication state of the failover group instance.
        public string ReplicationState { get; set; }
        //
        // Summary:
        //     Gets the list of database IDs in the failover group.
        public IReadOnlyList<string> Databases { get; set; }
        //
        // Summary:
        //     Gets the list of partner server information for the failover group.
        public IReadOnlyList<PartnerInfo> PartnerServers { get; set; }
        //
        // Summary:
        //     Gets name of the SQL Server to which this Failover Group belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets the failover policy of the read-only endpoint for the failover group.
        public ReadOnlyEndpointFailoverPolicy ReadOnlyEndpointPolicy { get; set; }
        //
        // Summary:
        //     Gets the grace period before failover with data loss is attempted for the read-write
        //     endpoint.
        public int ReadWriteEndpointDataLossGracePeriodMinutes { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }

        public bool Equals(HaISqlFailoverGroup other)
        {
            throw new NotImplementedException();
        }
    }
}
