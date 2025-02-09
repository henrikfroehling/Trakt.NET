namespace TraktNET
{
    public record class TMDBSeasonImages
    {
        public uint? Id { get; set; }

        public List<TMDBImage>? Posters { get; set; }
    }
}
