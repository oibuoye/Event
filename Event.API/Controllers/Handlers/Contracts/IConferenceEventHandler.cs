using Event.Core.Entities;
using Event.Core.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.API.Controllers.Handlers.Contracts
{
    public interface IConferenceEventHandler
    {
        /// <summary>
        /// Add new location
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> AddEvent(EventCreateVM model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ConferenceEventVM>> GetEvents();
    }
}
