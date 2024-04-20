namespace TraktNet.Objects.Get.Notes.Json.Factories
{
    using Get.Notes.Json.Reader;
    using Get.Notes.Json.Writer;
    using Objects.Json;

    internal class NoteItemJsonIOFactory : IJsonIOFactory<ITraktNoteItem>
    {
        public IObjectJsonReader<ITraktNoteItem> CreateObjectReader() => new NoteItemObjectJsonReader();

        public IObjectJsonWriter<ITraktNoteItem> CreateObjectWriter() => new NoteItemObjectJsonWriter();
    }
}
