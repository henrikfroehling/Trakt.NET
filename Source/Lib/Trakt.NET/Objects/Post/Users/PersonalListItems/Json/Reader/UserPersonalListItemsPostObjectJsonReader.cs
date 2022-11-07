namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    internal class UserPersonalListItemsPostObjectJsonReader : AUserPersonalListItemsPostObjectJsonReader<ITraktUserPersonalListItemsPost>
    {
        protected override ITraktUserPersonalListItemsPost CreateInstance() => new TraktUserPersonalListItemsPost();
    }
}
