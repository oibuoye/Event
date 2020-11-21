using Event.Core.Entities;
using Event.Core.HelperModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Event.Core.Services.Contracts
{
    public interface IConferenceEventService
    {
        /// <summary>
        /// Add new location
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> AddEvent(ConferenceEvent model);

        /// <summary>
        /// Update an location
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateEvent(ConferenceEventVM model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ConferenceEventVM>> GetEvents();
    }
}
