﻿namespace TraktNet.Requests.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRequestBody : IValidatable
    {
        Task<string> ToJson(CancellationToken cancellationToken = default);
    }
}
