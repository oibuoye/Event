using Event.API.Controllers.Handlers.Contracts;
using Event.Core.Entities;
using Event.Core.Exceptions;
using Event.Core.HelperModels;
using Event.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.API.Controllers.Handlers
{
    public class ConferenceEventHandler : IConferenceEventHandler
    {
        private readonly IConferenceEventService _eventService;

        public ConferenceEventHandler(IConferenceEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<bool> AddEvent(EventCreateVM model)
        {
            try
            {
                var conferenceEvent = new ConferenceEvent
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Date = DateTime.Now,
                    Time = model.Time,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    OnlineUrl = model.OnlineUrl,
                    Location = model.Location == null? null : new Location { Address = model.Location.Address, City = model.Location.City, Country = model.Location.Country}
                };
                await _eventService.AddEvent(conferenceEvent);
                return true;
            }
            catch (RecordAlreadyExistException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ConferenceEventVM>> GetEvents()
        {
          return await _eventService.GetEvents();
        }
    }
}
