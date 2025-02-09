namespace TraktNET
{
    public record class TMDBPersonImages
    {
        public uint? Id { get; set; }

        public List<TMDBImage>? Profiles { get; set; }
    }
}
