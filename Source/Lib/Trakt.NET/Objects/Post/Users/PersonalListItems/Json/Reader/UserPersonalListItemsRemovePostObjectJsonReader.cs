namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    internal class UserPersonalListItemsRemovePostObjectJsonReader : AUserPersonalListItemsPostObjectJsonReader<ITraktUserPersonalListItemsRemovePost>
    {
        protected override ITraktUserPersonalListItemsRemovePost CreateInstance() => new TraktUserPersonalListItemsRemovePost();
    }
}
