namespace TraktApiSharp.Objects.Get.Shows
{
    public interface ITraktTrendingShow : ITraktShow
    {
        int? Watchers { get; set; }

        ITraktShow Show { get; set; }
    }
}
