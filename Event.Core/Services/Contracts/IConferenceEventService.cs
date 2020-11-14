using Event.Core.Entities;
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
        Task<bool> UpdateEvent(ConferenceEvent model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ConferenceEvent>> GetEvents();
    }
}
