namespace TraktNET
{
    [TraktEnum]
    public enum TMDBProfileSize
    {
        Unspecified,

        [TraktEnumMember(JsonValue = "w45", DisplayName = "Width 45")]
        Width45,

        [TraktEnumMember(JsonValue = "w185", DisplayName = "Width 185")]
        Width185,

        [TraktEnumMember(JsonValue = "h632", DisplayName = "Height 632")]
        Height632,

        Original
    }
}
