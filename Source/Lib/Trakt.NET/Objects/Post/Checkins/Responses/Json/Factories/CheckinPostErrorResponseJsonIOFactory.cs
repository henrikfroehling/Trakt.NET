namespace TraktNet.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class CheckinPostErrorResponseJsonIOFactory : IJsonIOFactory<ITraktCheckinPostErrorResponse>
    {
        public IObjectJsonReader<ITraktCheckinPostErrorResponse> CreateObjectReader() => new CheckinPostErrorResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCheckinPostErrorResponse> CreateArrayReader() => new CheckinPostErrorResponseArrayJsonReader();

        public IObjectJsonWriter<ITraktCheckinPostErrorResponse> CreateObjectWriter() => new CheckinPostErrorResponseObjectJsonWriter();
    }
}
