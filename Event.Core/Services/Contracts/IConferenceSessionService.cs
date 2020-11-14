using Event.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Event.Core.Services.Contracts
{
    public interface IConferenceSessionService
    {
        /// <summary>
        /// Add new location
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> AddSession(ConferenceSession model);

        /// <summary>
        /// Update an location
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateSession(ConferenceSession model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ConferenceSession>> GetSessions();

        /// <summary>
        /// Get session details using the event id
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<ConferenceSession> GetSessionByEventId(string eventId);
    }
}
