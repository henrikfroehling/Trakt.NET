namespace TraktNET
{
    public class TraktShow : TraktShowMinimal
    {
        public string? Tagline { get; set; }

        public string? Overview { get; set; }

        public DateTime? FirstAired { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public TraktShowAirs? Airs { get; set; }

        public uint? Runtime { get; set; }

        public string? Certification { get; set; }

        public string? Network { get; set; }

        public string? Country { get; set; }

        public string? Trailer { get; set; }

        public string? Homepage { get; set; }

        public float? Rating { get; set; }

        public uint? Votes { get; set; }

        public uint? CommentCount { get; set; }

        public string? Language { get; set; }

        public IList<string>? Languages { get; set; }

        public IList<string>? AvailableTranslations { get; set; }

        public IList<string>? Genres { get; set; }

        public uint? AiredEpisodes { get; set; }

        public TraktShowStatus? Status { get; set; }
    }
}
