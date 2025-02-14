namespace TraktNET
{
    public record class TMDBConfigurationImages
    {
        public string? BaseUrl { get; set; }

        public string? SecureBaseUrl { get; set; }

        public List<TMDBBackdropSize>? BackdropSizes { get; set; }

        public List<TMDBLogoSize>? LogoSizes { get; set; }

        public List<TMDBPosterSize>? PosterSizes { get; set; }

        public List<TMDBProfileSize>? ProfileSizes { get; set; }

        public List<TMDBStillSize>? StillSizes { get; set; }
    }
}
