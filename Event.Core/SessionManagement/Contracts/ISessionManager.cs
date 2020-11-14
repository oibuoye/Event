using Event.Core.HelperModels;

namespace Event.Core.SessionManagement.Contracts
{
    public interface ISessionManager
    {
        /// <summary>
        /// Return cosmos client session
        /// </summary>
        /// <returns>CosmosClientObject</returns>
        CosmosClientObject GetSession();
    }
}
