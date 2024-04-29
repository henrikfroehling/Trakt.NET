namespace TraktNet.Objects.Post.Notes.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal sealed class NotePostJsonIOFactory : IJsonIOFactory<ITraktNotePost>
    {
        public IObjectJsonReader<ITraktNotePost> CreateObjectReader() => new NotePostObjectJsonReader();

        public IObjectJsonWriter<ITraktNotePost> CreateObjectWriter() => new NotePostObjectJsonWriter();
    }
}
