namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    internal class UserHiddenItemsRemovePostObjectJsonReader : AUserHiddenItemsPostObjectJsonReader<ITraktUserHiddenItemsRemovePost>
    {
        protected override ITraktUserHiddenItemsRemovePost CreateInstance() => new TraktUserHiddenItemsRemovePost();
    }
}
