namespace TraktNet.Objects.Get.Notes.Json.Factories
{
    using Get.Notes.Json.Reader;
    using Get.Notes.Json.Writer;
    using Objects.Json;

    internal class NoteAttachedToJsonIOFactory : IJsonIOFactory<ITraktNoteAttachedTo>
    {
        public IObjectJsonReader<ITraktNoteAttachedTo> CreateObjectReader() => new NoteAttachedToObjectJsonReader();

        public IObjectJsonWriter<ITraktNoteAttachedTo> CreateObjectWriter() => new NoteAttachedToObjectJsonWriter();
    }
}
