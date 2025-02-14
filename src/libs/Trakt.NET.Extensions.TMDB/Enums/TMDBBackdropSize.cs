namespace TraktNET
{
    [TraktEnum]
    public enum TMDBBackdropSize
    {
        Unspecified,

        [TraktEnumMember(JsonValue = "w300", DisplayName = "Width 300")]
        Width300,

        [TraktEnumMember(JsonValue = "w780", DisplayName = "Width 780")]
        Width780,

        [TraktEnumMember(JsonValue = "w1280", DisplayName = "Width 1280")]
        Width1280,

        Original
    }
}
