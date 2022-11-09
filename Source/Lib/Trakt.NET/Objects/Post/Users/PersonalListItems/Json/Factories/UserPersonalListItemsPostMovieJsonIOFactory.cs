namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostMovieJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostMovie>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostMovie> CreateObjectReader() => new UserPersonalListItemsPostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostMovie> CreateObjectWriter() => new UserPersonalListItemsPostMovieObjectJsonWriter();
    }
}
