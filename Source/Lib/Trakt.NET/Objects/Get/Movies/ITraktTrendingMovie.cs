namespace TraktNet.Objects.Get.Movies
{
    public interface ITraktTrendingMovie : ITraktMovie
    {
        int? Watchers { get; set; }

        ITraktMovie Movie { get; set; }
    }
}
