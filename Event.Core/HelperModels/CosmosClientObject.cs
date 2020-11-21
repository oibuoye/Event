using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.HelperModels
{
    public class CosmosClientObject
    {
        public CosmosClient Client { get; set; }

        public DatabaseResponse Database { get; set; }

        public string DBName { get; set; }
    }
}
