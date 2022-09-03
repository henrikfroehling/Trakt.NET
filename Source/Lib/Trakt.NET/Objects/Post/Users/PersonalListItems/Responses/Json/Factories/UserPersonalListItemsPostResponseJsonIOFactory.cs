namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostResponse> CreateObjectReader()
            => new UserPersonalListItemsPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostResponse> CreateObjectWriter()
            => new UserPersonalListItemsPostResponseObjectJsonWriter();
    }
}
