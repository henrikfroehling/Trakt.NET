namespace TraktApiSharp.Objects.Get.Episodes
{
    public interface ITraktEpisodeProgress
    {
        int? Number { get; set; }

        bool? Completed { get; set; }
    }
}
