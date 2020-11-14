using Event.Core.Services.Contracts;
using Event.Core.SessionManagement.Contracts;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Core.Logger.Contracts;
using Event.Core.Entities;

namespace Event.Core.Services
{
    public class ConferenceEventService : IConferenceEventService
    {
        private static ISessionManager _cosmosSession;
        private static IFileLogger _log;

        public ConferenceEventService(IFileLogger log, ISessionManager cosmosSession)
        {
            _cosmosSession = cosmosSession;
            _log = log;
        }

        public async Task<bool> AddEvent(ConferenceEvent model)
        {
            var clientObject = _cosmosSession.GetSession();
            var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceEvent).Name);
            var response = await container.CreateItemAsync(model, new PartitionKey(model.Id));
            _log.Info($"Added new location: {response.RequestCharge} RUs");
            return true;
        }

        public async Task<IEnumerable<ConferenceEvent>> GetEvents()
        {
            var clientObject = _cosmosSession.GetSession();
            var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceEvent).Name);
            var sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<ConferenceEvent>(sql);
            var page = await iterator.ReadNextAsync();

            return page.Resource;
        }

        public async Task<bool> UpdateEvent(ConferenceEvent model)
        {
            try
            {
                var clientObject = _cosmosSession.GetSession();
                var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceEvent).Name);
                var response = await container.ReplaceItemAsync<dynamic>(model, model.Id.ToString(), partitionKey: new PartitionKey(model.Id));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
