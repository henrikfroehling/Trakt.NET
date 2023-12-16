namespace TraktNet.Objects.Get.Users.Notes.Json.Factories
{
    using Get.Users.Notes.Json.Reader;
    using Get.Users.Notes.Json.Writer;
    using Objects.Json;

    internal class UserNoteAttachedToJsonIOFactory : IJsonIOFactory<ITraktUserNoteAttachedTo>
    {
        public IObjectJsonReader<ITraktUserNoteAttachedTo> CreateObjectReader() => new UserNoteAttachedToObjectJsonReader();

        public IObjectJsonWriter<ITraktUserNoteAttachedTo> CreateObjectWriter() => new UserNoteAttachedToObjectJsonWriter();
    }
}
