namespace TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCheckinPostErrorResponseJsonReaderFactory : ITraktJsonReaderFactory<ITraktCheckinPostErrorResponse>
    {
        public ITraktObjectJsonReader<ITraktCheckinPostErrorResponse> CreateObjectReader() => new TraktCheckinPostErrorResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCheckinPostErrorResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCheckinPostErrorResponse)} is not supported.");
        }
    }
}
