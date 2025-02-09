namespace TraktNET
{
    public record class TMDBConfiguration
    {
        public List<string>? ChangeKeys { get; set; }

        public TMDBConfigurationImages? Images { get; set; }
    }
}
