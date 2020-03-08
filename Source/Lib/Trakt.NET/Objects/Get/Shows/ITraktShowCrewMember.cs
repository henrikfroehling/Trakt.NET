namespace TraktNet.Objects.Get.Shows
{
    using Objects.Basic;

    /// <summary>A Trakt show crew member.</summary>
    public interface ITraktShowCrewMember : ITraktCrewMember
    {
        /// <summary>Gets or sets the episode count of the crew member.<para>Nullable</para></summary>
        int? EpisodeCount { get; set; }
    }
}
