namespace TraktNet.Objects.Get.Users.Notes.Json.Factories
{
    using Get.Users.Notes.Json.Reader;
    using Get.Users.Notes.Json.Writer;
    using Objects.Json;

    internal class UserNoteItemJsonIOFactory : IJsonIOFactory<ITraktUserNoteItem>
    {
        public IObjectJsonReader<ITraktUserNoteItem> CreateObjectReader() => new UserNoteItemObjectJsonReader();

        public IObjectJsonWriter<ITraktUserNoteItem> CreateObjectWriter() => new UserNoteItemObjectJsonWriter();
    }
}
