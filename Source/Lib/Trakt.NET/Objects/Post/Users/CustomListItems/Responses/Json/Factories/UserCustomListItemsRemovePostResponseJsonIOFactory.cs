namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateObjectReader()
            => new UserCustomListItemsRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsRemovePostResponse> CreateObjectWriter()
            => new UserCustomListItemsRemovePostResponseObjectJsonWriter();
    }
}
