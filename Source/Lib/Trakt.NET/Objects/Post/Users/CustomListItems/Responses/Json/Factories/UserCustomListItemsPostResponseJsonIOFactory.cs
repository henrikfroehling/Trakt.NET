namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponse> CreateObjectReader()
            => new UserCustomListItemsPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponse> CreateObjectWriter()
            => new UserCustomListItemsPostResponseObjectJsonWriter();
    }
}
