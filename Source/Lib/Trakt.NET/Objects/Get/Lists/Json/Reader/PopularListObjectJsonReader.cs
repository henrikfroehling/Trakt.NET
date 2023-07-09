namespace TraktNet.Objects.Get.Lists.Json.Reader
{
    internal class PopularListObjectJsonReader : ATrendingOrPopularListObjectJsonReader<ITraktPopularList>
    {
        protected override ITraktPopularList CreateListObject() => new TraktPopularList();
    }
}
