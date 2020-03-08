namespace TraktNet.Objects.Get.Shows
{
    using Objects.Basic;

    /// <summary>A Trakt show cast member.</summary>
    public interface ITraktShowCastMember : ITraktCastMember
    {
        /// <summary>Gets or sets the episode count of the cast member.<para>Nullable</para></summary>
        int? EpisodeCount { get; set; }
    }
}
