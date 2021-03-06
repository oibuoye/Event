﻿using Event.Core.Configuration;
using Event.Core.HelperModels;
using Event.Core.SessionManagement.Contracts;
using Microsoft.Azure.Cosmos;
using System;

namespace Event.Core.SessionManagement
{
    public class SessionManager : ISessionManager
    {
        public static CosmosClient Client { get; set; }
        public static DatabaseResponse database { get; set; }

        private readonly ICosmosDBSettings _cosmosDBSettings;

        public SessionManager(ICosmosDBSettings cosmosDBSettings)
        {
            _cosmosDBSettings = cosmosDBSettings;
        }

        /// <summary>
        /// This returns CosmosClientObject object containing cosmos client session and database Id
        /// </summary>
        /// <returns>CosmosClientObject</returns>
        public CosmosClientObject GetSession()
        {
            if (Client == null)
            {
                try
                {
                    Client = new CosmosClient(_cosmosDBSettings.Endpoint, _cosmosDBSettings.MasterKey);
                    database = Client.CreateDatabaseIfNotExistsAsync(_cosmosDBSettings.DBName).Result;
                    return new CosmosClientObject { Client = Client, DBName = _cosmosDBSettings.DBName, Database = database};
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return new CosmosClientObject { Client = Client, DBName = _cosmosDBSettings.DBName, Database = database };
        }
    }
}
