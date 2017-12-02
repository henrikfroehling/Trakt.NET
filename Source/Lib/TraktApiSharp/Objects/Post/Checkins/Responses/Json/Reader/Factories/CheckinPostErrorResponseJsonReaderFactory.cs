namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Checkins.Responses.Json.Reader;
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
