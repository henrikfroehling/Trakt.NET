namespace TraktNET
{
    [TraktEnum]
    public enum TMDBStillSize
    {
        Unspecified,

        [TraktEnumMember(JsonValue = "w92", DisplayName = "Width 92")]
        Width82,

        [TraktEnumMember(JsonValue = "w185", DisplayName = "Width 185")]
        Width185,

        [TraktEnumMember(JsonValue = "w300", DisplayName = "Width 300")]
        Width300,

        Original
    }
}
