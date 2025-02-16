namespace TraktNET
{
    public record class TMDBErrorResponse
    {
        public bool? Success { get; set; }

        public uint? StatusCode { get; set; }

        public string? StatusMessage { get; set; }
    }
}
