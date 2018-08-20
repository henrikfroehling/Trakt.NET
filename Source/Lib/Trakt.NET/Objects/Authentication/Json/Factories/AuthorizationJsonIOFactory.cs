namespace TraktNet.Objects.Authentication.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class AuthorizationJsonIOFactory : IJsonIOFactory<ITraktAuthorization>
    {
        public IObjectJsonReader<ITraktAuthorization> CreateObjectReader() => new AuthorizationObjectJsonReader();

        public IArrayJsonReader<ITraktAuthorization> CreateArrayReader() => new AuthorizationArrayJsonReader();

        public IObjectJsonWriter<ITraktAuthorization> CreateObjectWriter() => new AuthorizationObjectJsonWriter();
    }
}
