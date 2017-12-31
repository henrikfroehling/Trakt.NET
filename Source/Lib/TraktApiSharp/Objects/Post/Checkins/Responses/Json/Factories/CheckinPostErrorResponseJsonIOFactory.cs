namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Checkins.Responses.Json.Reader;
    using System;

    internal class CheckinPostErrorResponseJsonIOFactory : IJsonIOFactory<ITraktCheckinPostErrorResponse>
    {
        public IObjectJsonReader<ITraktCheckinPostErrorResponse> CreateObjectReader() => new CheckinPostErrorResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCheckinPostErrorResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCheckinPostErrorResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktCheckinPostErrorResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktCheckinPostErrorResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
