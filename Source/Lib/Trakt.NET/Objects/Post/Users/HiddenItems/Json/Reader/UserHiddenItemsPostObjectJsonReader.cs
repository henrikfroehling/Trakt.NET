namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    internal class UserHiddenItemsPostObjectJsonReader : AUserHiddenItemsPostObjectJsonReader<ITraktUserHiddenItemsPost>
    {
        protected override ITraktUserHiddenItemsPost CreateInstance() => new TraktUserHiddenItemsPost();
    }
}
