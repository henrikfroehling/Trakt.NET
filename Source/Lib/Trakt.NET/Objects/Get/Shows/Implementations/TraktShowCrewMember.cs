namespace TraktNet.Objects.Get.Shows
{
    using Objects.Basic;

    /// <summary>A Trakt show crew member.</summary>
    public class TraktShowCrewMember : TraktCrewMember, ITraktShowCrewMember
    {
        /// <summary>Gets or sets the episode count of the crew member.<para>Nullable</para></summary>
        public int? EpisodeCount { get; set; }
    }
}
