namespace TraktNet.Objects.Get.Users.Statistics
{
    public interface ITraktUserSeasonsStatistics
    {
        int? Ratings { get; set; }

        int? Comments { get; set; }
    }
}
