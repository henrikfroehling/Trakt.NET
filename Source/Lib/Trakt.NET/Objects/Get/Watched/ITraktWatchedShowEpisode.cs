namespace TraktNet.Objects.Get.Watched
{
    using System;

    public interface ITraktWatchedShowEpisode
    {
        int? Number { get; set; }

        int? Plays { get; set; }

        DateTime? LastWatchedAt { get; set; }
    }
}
