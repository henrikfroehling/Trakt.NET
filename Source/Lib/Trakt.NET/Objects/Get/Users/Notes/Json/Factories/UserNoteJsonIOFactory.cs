namespace TraktNet.Objects.Get.Users.Notes.Json.Factories
{
    using Get.Users.Notes.Json.Reader;
    using Get.Users.Notes.Json.Writer;
    using Objects.Json;

    internal class UserNoteJsonIOFactory : IJsonIOFactory<ITraktUserNote>
    {
        public IObjectJsonReader<ITraktUserNote> CreateObjectReader() => new UserNoteObjectJsonReader();

        public IObjectJsonWriter<ITraktUserNote> CreateObjectWriter() => new UserNoteObjectJsonWriter();
    }
}
