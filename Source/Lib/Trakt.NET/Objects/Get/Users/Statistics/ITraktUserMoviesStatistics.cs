namespace TraktNet.Objects.Get.Users.Statistics
{
    public interface ITraktUserMoviesStatistics
    {
        int? Plays { get; set; }

        int? Watched { get; set; }

        int? Minutes { get; set; }

        int? Collected { get; set; }

        int? Ratings { get; set; }

        int? Comments { get; set; }
    }
}
