namespace TraktNet.Objects.Get.Watched
{
    using Movies;
    using System;

    public interface ITraktWatchedMovie : ITraktMovie
    {
        int? Plays { get; set; }

        DateTime? LastWatchedAt { get; set; }

        ITraktMovie Movie { get; set; }
    }
}
