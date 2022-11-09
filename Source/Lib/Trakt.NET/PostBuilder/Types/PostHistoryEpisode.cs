﻿namespace TraktNet.PostBuilder
{
    using System;

    /// <summary>Contains an episode number and an optional datetime, when it was watched.</summary>
    public sealed class PostHistoryEpisode
    {
        /// <summary>Gets the number of this episode.</summary>
        public int Number { get; }

        /// <summary>Gets the optional UTC datetime, when this episode was watched.</summary>
        public DateTime? WatchedAt { get; }

        /// <summary>Initializes a new instance of the <see cref="PostHistoryEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        public PostHistoryEpisode(int number) => Number = number;

        /// <summary>Initializes a new instance of the <see cref="PostHistoryEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="watchedAt">The UTC datetime, when this episode was watched.</param>
        public PostHistoryEpisode(int number, DateTime watchedAt)
            : this(number)
            => WatchedAt = watchedAt.ToUniversalTime();
    }
}
