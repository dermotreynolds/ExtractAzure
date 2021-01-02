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
    public class HaISqlEncryptionProtectorModel //: IEquatable<HaISqlEncryptionProtectorModel>
    {
        //public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string SubscriptionId { get; set; }

        public string Region { get; set; }

        public string RegionName { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }
        //
        // Summary:
        //     Gets the encryption protector type.
        public ServerKeyType ServerKeyType { get; set; }
        //
        // Summary:
        //     Gets the name of the server key.
        public string ServerKeyName { get; set; }
        //
        // Summary:
        //     Gets name of the SQL Server to which this DNS alias belongs.
        public string SqlServerName { get; set; }
        //
        // Summary:
        //     Gets the kind of encryption protector; this is metadata used for the Azure Portal
        //     experience.
        public string Kind { get; set; }
        //
        // Summary:
        //     Gets thumbprint of the server key.
        public string Thumbprint { get; set; }

        //
        // Summary:
        //     Gets the URI of the server key.
        public string Uri { get; set; }
        //
        // Summary:
        //     Gets the parent SQL server ID.
        public string ParentId { get; set; }

        public bool Equals(HaISqlEncryptionProtectorModel other)
        {
            throw new NotImplementedException();
        }
    }
}
