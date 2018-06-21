namespace TraktNet.Objects.Get.Users.Statistics
{
    public interface ITraktUserStatistics
    {
        ITraktUserMoviesStatistics Movies { get; set; }

        ITraktUserShowsStatistics Shows { get; set; }

        ITraktUserSeasonsStatistics Seasons { get; set; }

        ITraktUserEpisodesStatistics Episodes { get; set; }

        ITraktUserNetworkStatistics Network { get; set; }

        ITraktUserRatingsStatistics Ratings { get; set; }
    }
}
