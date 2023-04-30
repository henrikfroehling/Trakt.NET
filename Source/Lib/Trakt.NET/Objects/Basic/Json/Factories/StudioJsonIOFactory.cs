namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class StudioJsonIOFactory : IJsonIOFactory<ITraktStudio>
    {
        public IObjectJsonReader<ITraktStudio> CreateObjectReader() => new StudioObjectJsonReader();

        public IObjectJsonWriter<ITraktStudio> CreateObjectWriter() => new StudioObjectJsonWriter();
    }
}
