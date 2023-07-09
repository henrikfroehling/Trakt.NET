namespace TraktNet.Objects.Get.Lists.Json.Reader
{
    internal class TrendingListObjectJsonReader : ATrendingOrPopularListObjectJsonReader<ITraktTrendingList>
    {
        protected override ITraktTrendingList CreateListObject() => new TraktTrendingList();
    }
}
