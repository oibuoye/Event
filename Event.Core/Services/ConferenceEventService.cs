using Event.Core.Services.Contracts;
using Event.Core.SessionManagement.Contracts;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Core.Logger.Contracts;
using Event.Core.Entities;
using Event.Core.HelperModels;

namespace Event.Core.Services
{
    public class ConferenceEventService : IConferenceEventService
    {
        private static ISessionManager _cosmosSession;
        private static IFileLogger _log;
        private static ContainerResponse _containerResponse;

        public ConferenceEventService(IFileLogger log, ISessionManager cosmosSession)
        {
            _cosmosSession = cosmosSession;
            GetContainer();
            _log = log;
        }

        public async Task<bool> AddEvent(ConferenceEvent model)
        {
            try
            {
                var response = await _containerResponse.Container.CreateItemAsync(model);
                _log.Info($"Added new location: {response.RequestCharge} RUs");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ConferenceEventVM>> GetEvents()
        {
            var sql = "SELECT * FROM c";
            var iterator = _containerResponse.Container.GetItemQueryIterator<ConferenceEventVM>(sql);
            var page = await iterator.ReadNextAsync();

            return page.Resource;
        }

        public async Task<bool> UpdateEvent(ConferenceEventVM model)
        {
            try
            {
                var response = await _containerResponse.Container.ReplaceItemAsync<dynamic>(model, model.Id.ToString());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void GetContainer()
        {
            CosmosClientObject _sessionObject = _cosmosSession.GetSession();
            _containerResponse = _sessionObject.Database.Database.CreateContainerIfNotExistsAsync(typeof(ConferenceEvent).Name, "/time", 400).Result;
        }
    }

}
