namespace TraktNet.Objects.Get.Shows
{
    using Objects.Basic;

    /// <summary>A Trakt show cast member.</summary>
    public class TraktShowCastMember : TraktCastMember, ITraktShowCastMember
    {
        /// <summary>Gets or sets the episode count of the cast member.<para>Nullable</para></summary>
        public int? EpisodeCount { get; set; }
    }
}
