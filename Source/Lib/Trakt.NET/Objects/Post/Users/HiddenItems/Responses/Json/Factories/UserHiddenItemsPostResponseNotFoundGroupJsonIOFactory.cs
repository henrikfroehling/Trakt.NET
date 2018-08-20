namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostResponseNotFoundGroup> CreateObjectReader()
            => new UserHiddenItemsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsPostResponseNotFoundGroup> CreateArrayReader()
            => new UserHiddenItemsPostResponseNotFoundGroupArrayJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPostResponseNotFoundGroup> CreateObjectWriter()
            => new UserHiddenItemsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
