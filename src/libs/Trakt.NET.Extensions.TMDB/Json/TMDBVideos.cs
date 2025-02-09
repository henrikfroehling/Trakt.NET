namespace TraktNET
{
    public record class TMDBVideos
    {
        public uint? Id { get; set; }

        public List<TMDBVideo>? Results { get; set; }
    }
}
