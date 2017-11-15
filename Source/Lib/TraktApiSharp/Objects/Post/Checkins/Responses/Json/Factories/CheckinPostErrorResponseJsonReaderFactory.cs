namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class CheckinPostErrorResponseJsonReaderFactory : IJsonReaderFactory<ITraktCheckinPostErrorResponse>
    {
        public IObjectJsonReader<ITraktCheckinPostErrorResponse> CreateObjectReader() => new CheckinPostErrorResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCheckinPostErrorResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCheckinPostErrorResponse)} is not supported.");
        }
    }
}
