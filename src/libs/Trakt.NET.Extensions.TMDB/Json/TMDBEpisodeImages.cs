namespace TraktNET
{
    public record class TMDBEpisodeImages
    {
        public uint? Id { get; set; }

        public List<TMDBImage>? Stills { get; set; }
    }
}
