namespace TraktNet.Objects.Get.Syncs.Playback
{
    using Enums;
    using Episodes;
    using Movies;
    using Shows;
    using System;

    public interface ITraktSyncPlaybackProgressItem
    {
        uint Id { get; set; }

        float? Progress { get; set; }

        DateTime? PausedAt { get; set; }

        TraktSyncType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktEpisode Episode { get; set; }

        ITraktShow Show { get; set; }
    }
}
