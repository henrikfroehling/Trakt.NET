namespace TraktNET
{
    [TraktEnum]
    public enum TMDBLogoSize
    {
        Unspecified,

        [TraktEnumMember(JsonValue = "w45", DisplayName = "Width 45")]
        Width45,

        [TraktEnumMember(JsonValue = "w92", DisplayName = "Width 92")]
        Width92,

        [TraktEnumMember(JsonValue = "w154", DisplayName = "Width 154")]
        Width154,

        [TraktEnumMember(JsonValue = "w185", DisplayName = "Width 185")]
        Width185,

        [TraktEnumMember(JsonValue = "w300", DisplayName = "Width 300")]
        Width300,

        [TraktEnumMember(JsonValue = "w500", DisplayName = "Width 500")]
        Width500,

        Original
    }
}
