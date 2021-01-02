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
    class HaISqlServerKey // : IEquatable<HaISqlServerKey>
    {
        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string SubscriptionId { get; set; }

        public Region Region { get; set; }

        public string RegionName { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        public ServerKeyType ServerKeyType { get; set; }

        public string SqlServerName { get; set; }

        public string Kind { get; set; }

        public string Thumbprint { get; set; }

        public DateTime? CreationDate { get; set; }

        public string Uri { get; set; }

        public string ParentId { get; set; }


        public bool Equals(HaISqlServerKey other)
        {
            if (other == null) return false;
            HaISqlServerKey objAsPart = other as HaISqlServerKey;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
    }
}
