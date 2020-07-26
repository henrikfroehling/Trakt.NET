namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class ErrorJsonIOFactory : IJsonIOFactory<ITraktError>
    {
        public IObjectJsonReader<ITraktError> CreateObjectReader() => new ErrorObjectJsonReader();

        public IObjectJsonWriter<ITraktError> CreateObjectWriter() => new ErrorObjectJsonWriter();
    }
}
