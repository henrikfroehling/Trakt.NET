namespace TraktApiSharp.Objects.Basic
{
    public interface ITraktStatistics
    {
        int? Watchers { get; set; }

        int? Plays { get; set; }

        int? Collectors { get; set; }

        int? CollectedEpisodes { get; set; }

        int? Comments { get; set; }

        int? Lists { get; set; }

        int? Votes { get; set; }
    }
}
