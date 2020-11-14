using Event.Core.Entities;
using Event.Core.Logger.Contracts;
using Event.Core.Services.Contracts;
using Event.Core.SessionManagement.Contracts;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Services
{
    public class ConferenceSessionService : IConferenceSessionService
    {

        private static ISessionManager _cosmosSession;
        private static IFileLogger _log;

        public ConferenceSessionService(IFileLogger log, ISessionManager cosmosSession)
        {
            _cosmosSession = cosmosSession;
            _log = log;
        }

        public async Task<bool> AddSession(ConferenceSession model)
        {
            var clientObject = _cosmosSession.GetSession();
            var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceSession).Name);
            var response = await container.CreateItemAsync(model, new PartitionKey(model.Id));
            _log.Info($"Added new location: {response.RequestCharge} RUs");
            return true;
        }


        public async Task<ConferenceSession> GetSessionByEventId(string eventId)
        {
            var clientObject = _cosmosSession.GetSession();
            var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceSession).Name);
            var sql = $"SELECT * FROM c WHERE c.eventid ='{eventId}'";
            var iterator = container.GetItemQueryIterator<ConferenceSession>(sql);
            var page = await iterator.ReadNextAsync();

            foreach (var item in page)
            {
                return item;
            }
            return new ConferenceSession { };
        }

        public async Task<IEnumerable<ConferenceSession>> GetSessions()
        {
            var clientObject = _cosmosSession.GetSession();
            var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceSession).Name);
            var sql = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<ConferenceSession>(sql);
            var page = await iterator.ReadNextAsync();

            return page.Resource;
        }

        public async Task<bool> UpdateSession(ConferenceSession model)
        {
            try
            {
                var clientObject = _cosmosSession.GetSession();
                var container = clientObject.Client.GetContainer(clientObject.DBName, typeof(ConferenceSession).Name);
                var response = await container.ReplaceItemAsync<dynamic>(model, model.Id.ToString(), partitionKey: new PartitionKey(model.Id));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
