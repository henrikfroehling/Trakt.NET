namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    public interface ITraktUserShowsStatistics
    {
        int? Watched { get; set; }

        int? Collected { get; set; }

        int? Ratings { get; set; }

        int? Comments { get; set; }
    }
}
