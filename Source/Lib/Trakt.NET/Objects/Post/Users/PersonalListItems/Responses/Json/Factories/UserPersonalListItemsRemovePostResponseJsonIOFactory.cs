namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsRemovePostResponse> CreateObjectReader()
            => new UserPersonalListItemsRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsRemovePostResponse> CreateObjectWriter()
            => new UserPersonalListItemsRemovePostResponseObjectJsonWriter();
    }
}
