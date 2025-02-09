namespace TraktNET
{
    public record class TMDBConfigurationImages
    {
        public string? BaseUrl { get; set; }

        public string? SecureBaseUrl { get; set; }

        public List<string>? BackdropSizes { get; set; }

        public List<string>? LogoSizes { get; set; }

        public List<string>? PosterSizes { get; set; }

        public List<string>? ProfileSizes { get; set; }

        public List<string>? StillSizes { get; set; }
    }
}
