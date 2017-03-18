namespace TraktApiSharp.Objects.Get.Episodes
{
    using System;

    public interface ITraktEpisodeCollectionProgress : ITraktEpisodeProgress
    {
        DateTime? CollectedAt { get; set; }
    }
}
