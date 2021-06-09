namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class RateLimitInfoJsonIOFactory : IJsonIOFactory<ITraktRateLimitInfo>
    {
        public IObjectJsonReader<ITraktRateLimitInfo> CreateObjectReader() => new RateLimitInfoObjectJsonReader();

        public IObjectJsonWriter<ITraktRateLimitInfo> CreateObjectWriter() => new RateLimitInfoObjectJsonWriter();
    }
}
