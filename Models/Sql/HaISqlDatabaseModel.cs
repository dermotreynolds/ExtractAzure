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
using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupActionsDefinition;

using System;



namespace ExrtractAzure
{
    class HaISqlDatabase // : IEquatable<HaISqlDatabase>
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
        //     Gets the status of the Azure SQL Database.
        public string Status { get; set; }
        //
        // Summary:
        //     Gets the elasticPoolName value.
        public string ElasticPoolName { get; set; }
    
        //
        // Summary:
        //     Gets the edition of the Azure SQL Database.
        public DatabaseEdition Edition { get; set; }
        //
        // Summary:
        //     Gets the SQL Sync Group entry point for the current database.
        public ISqlSyncGroupActionsDefinition SyncGroups { get; set; }
        //
        // Summary:
        //     Gets the current Service Level Objective Id of the Azure SQL Database, this is
        //     the Id of the Service Level Objective that is currently active.
        public Guid? CurrentServiceObjectiveId { get; set; }
        //
        // Summary:
        //     Gets the max size of the Azure SQL Database expressed in bytes.
        public long MaxSizeBytes { get; set; }
        //
        // Summary:
        //     Gets the defaultSecondaryLocation value.
        public string DefaultSecondaryLocation { get; set; }
        //
        // Summary:
        //     Gets the configured Service Level Objective Id of the Azure SQL Database, this
        //     is the Service Level Objective that is being applied to the Azure SQL Database.
        public Guid? RequestedServiceObjectiveId { get; set; }
        //
        // Summary:
        //     Gets the tags for the current SQL Database
        public IReadOnlyDictionary<string, string> Tags { get; set; }
        public string TagsValue { get; set; }
        //
        // Summary:
        //     Gets the collation of the Azure SQL Database.
        public string Collation { get; set; }
        //
        // Summary:
        //     Gets the recovery period start date of the Azure SQL Database. This records the
        //     start date and time when recovery is available for this Azure SQL Database.
        public DateTime? EarliestRestoreDate { get; set; }
        //
        // Summary:
        //     Gets the name of the configured Service Level Objective of the Azure SQL Database,
        //     this is the Service Level Objective that is being applied to the Azure SQL Database.
        public ServiceObjectiveName RequestedServiceObjectiveName { get; set; }
        //
        // Summary:
        //     Gets name of the SQL Server to which this database belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets the creation date of the Azure SQL Database.
        public DateTime? CreationDate { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }
        //
        // Summary:
        //     Gets the Service Level Objective of the Azure SQL Database.
        public ServiceObjectiveName ServiceLevelObjective { get; set; }
        //
        // Summary:
        //     Gets true if this Database is SqlWarehouse.
        public bool IsDataWarehouse { get; set; }
        //
        // Summary:
        //     Gets the Id of the Azure SQL Database.
        public string DatabaseId { get; set; }

        public bool Equals(HaISqlDatabase other)
        {
            if (other == null) return false;
            HaISqlDatabase objAsPart = other as HaISqlDatabase;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
    }
}
