namespace TraktApiSharp.Objects.Get.Seasons
{
    public interface ITraktSeasonProgress
    {
        int? Number { get; set; }

        int? Aired { get; set; }

        int? Completed { get; set; }
    }
}
