namespace TraktNET
{
    public record class TMDBShowImages
    {
        public uint? Id { get; set; }

        public List<TMDBImage>? Backdrops { get; set; }

        public List<TMDBImage>? Posters { get; set; }

        public List<TMDBImage>? Logos { get; set; }
    }
}
