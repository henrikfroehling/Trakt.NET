namespace TraktNet.Objects.Authentication.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class AuthorizationJsonIOFactory : IJsonIOFactory<ITraktAuthorization>
    {
        public IObjectJsonReader<ITraktAuthorization> CreateObjectReader() => new AuthorizationObjectJsonReader();

        public IArrayJsonReader<ITraktAuthorization> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktAuthorization)} is not supported.");

        public IObjectJsonWriter<ITraktAuthorization> CreateObjectWriter() => new AuthorizationObjectJsonWriter();
    }
}
