namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Checkins.Responses.Json.Reader;
    using System;

    internal class CheckinPostErrorResponseJsonReaderFactory : IJsonIOFactory<ITraktCheckinPostErrorResponse>
    {
        public IObjectJsonReader<ITraktCheckinPostErrorResponse> CreateObjectReader() => new CheckinPostErrorResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCheckinPostErrorResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCheckinPostErrorResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktCheckinPostErrorResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktCheckinPostErrorResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
