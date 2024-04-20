namespace TraktNet.Objects.Get.Notes.Json.Factories
{
    using Get.Notes.Json.Reader;
    using Get.Notes.Json.Writer;
    using Objects.Json;

    internal class NoteJsonIOFactory : IJsonIOFactory<ITraktNote>
    {
        public IObjectJsonReader<ITraktNote> CreateObjectReader() => new NoteObjectJsonReader();

        public IObjectJsonWriter<ITraktNote> CreateObjectWriter() => new NoteObjectJsonWriter();
    }
}
