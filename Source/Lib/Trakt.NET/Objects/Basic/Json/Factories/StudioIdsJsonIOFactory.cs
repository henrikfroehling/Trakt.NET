namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class StudioIdsJsonIOFactory : IJsonIOFactory<ITraktStudioIds>
    {
        public IObjectJsonReader<ITraktStudioIds> CreateObjectReader() => new StudioIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktStudioIds> CreateObjectWriter() => new StudioIdsObjectJsonWriter();
    }
}
