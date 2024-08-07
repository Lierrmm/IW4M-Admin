﻿using System.Threading;
using System.Threading.Tasks;
using SharedLibraryCore.RCon;

namespace SharedLibraryCore.Interfaces
{
    /// <summary>
    ///     defines the capabilities of an RCon connection
    /// </summary>
    public interface IRConConnection
    {
        /// <summary>
        ///     sends a query with the instance of the rcon connection
        /// </summary>
        /// <param name="type">type of RCon query to perform</param>
        /// <param name="parameters">optional parameter list</param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string[]> SendQueryAsync(StaticHelpers.QueryType type, string parameters = "", CancellationToken token = default);

        /// <summary>
        ///     sets the rcon parser
        /// </summary>
        /// <param name="config">parser</param>
        void SetConfiguration(IRConParser config);
    }
}
