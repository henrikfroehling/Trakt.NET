namespace TraktNET
{
    public class TraktEpisodeMinimal
    {
        public uint? Season { get; set; }

        public uint? Number { get; set; }

        public string? Title { get; set; }

        public TraktEpisodeIds? Ids { get; set; }
    }
}
