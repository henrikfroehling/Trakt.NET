﻿using System.Text.Json.Serialization;

namespace TraktNET
{
    public class TraktEpisode : TraktEpisodeMinimal
    {
        [JsonPropertyName("number_abs")]
        public uint? NumberAbsolute { get; set; }

        public string? Overview { get; set; }

        public float? Rating { get; set; }

        public uint? Votes { get; set; }

        public uint? CommentCount { get; set; }

        public DateTime? FirstAired { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public uint? Runtime { get; set; }

        public TraktEpisodeType? EpisodeType { get; set; }

        public IList<string>? AvailableTranslations { get; set; }

        public IList<TraktEpisodeTranslation>? Translations { get; set; }
    }
}
