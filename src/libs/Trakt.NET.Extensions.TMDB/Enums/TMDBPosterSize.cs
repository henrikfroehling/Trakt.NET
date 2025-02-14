namespace TraktNET
{
    [TraktEnum]
    public enum TMDBPosterSize
    {
        Unspecified,

        [TraktEnumMember(JsonValue = "w92", DisplayName = "Width 92")]
        Width92,

        [TraktEnumMember(JsonValue = "w154", DisplayName = "Width 154")]
        Width154,

        [TraktEnumMember(JsonValue = "w185", DisplayName = "Width 185")]
        Width185,

        [TraktEnumMember(JsonValue = "w342", DisplayName = "Width 342")]
        Width342,

        [TraktEnumMember(JsonValue = "w500", DisplayName = "Width 500")]
        Width500,

        [TraktEnumMember(JsonValue = "w780", DisplayName = "Width 780")]
        Width780,

        Original
    }
}
