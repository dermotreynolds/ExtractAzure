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
using Microsoft.Azure.Management.Sql.Fluent.Models;

using System;



namespace ExrtractAzure
{
    class HaISqlElasticPool : IEquatable<HaISqlElasticPool>
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
        //     Gets the minimum DTU all SQL Azure Databases are guaranteed.
        public int DatabaseDtuMin { get; set; }
        //
        // Summary:
        //     Gets the edition of Azure SQL Elastic Pool.
        public ElasticPoolEdition Edition { get; set; }
        //
        // Summary:
        //     Gets the maximum DTU any one SQL Azure database can consume.
        public int DatabaseDtuMax { get; set; }
        //
        // Summary:
        //     Gets the storage limit for the SQL Azure Database Elastic Pool in MB.
        public int StorageMB { get; set; }
        //
        // Summary:
        //     Gets name of the SQL Server to which this elastic pool belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets the state of the Azure SQL Elastic Pool.
        public ElasticPoolState State { get; set; }
        //
        // Summary:
        //     Gets The total shared DTU for the SQL Azure Database Elastic Pool.
        public int Dtu { get; set; }
        //
        // Summary:
        //     Gets the storage capacity limit for the SQL Azure Database Elastic Pool in MB.
        public int StorageCapacityInMB { get; set; }
        //
        // Summary:
        //     Gets the creation date of the Azure SQL Elastic Pool.
        public DateTime CreationDate { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }

        public bool Equals(HaISqlElasticPool other)
        {
            if (other == null) return false;
            HaISqlElasticPool objAsPart = other as HaISqlElasticPool;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
    }
}
