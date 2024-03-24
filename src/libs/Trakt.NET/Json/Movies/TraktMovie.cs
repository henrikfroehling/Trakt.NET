namespace TraktNET
{
    public class TraktMovie : TraktMovieMinimal
    {
        public string? Tagline { get; set; }

        public string? Overview { get; set; }

#if NET6_0_OR_GREATER
        public DateOnly? Released { get; set; }
#else
        public string? Released { get; set; }
#endif

        public uint? Runtime { get; set; }

        public string? Country { get; set; }

        public string? Trailer { get; set; }

        public string? Homepage { get; set; }

        public TraktMovieStatus? Status { get; set; }

        public float? Rating { get; set; }

        public uint? Votes { get; set; }

        public uint? CommentCount { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? Language { get; set; }

        public IList<string>? Languages { get; set; }

        public IList<string>? AvailableTranslations { get; set; }

        public IList<string>? Genres { get; set; }

        public string? Certification { get; set; }
    }
}
