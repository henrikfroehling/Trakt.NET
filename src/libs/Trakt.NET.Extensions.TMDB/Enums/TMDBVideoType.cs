namespace TraktNET
{
    [TraktEnum]
    public enum TMDBVideoType
    {
        Unspecified,

        [TraktEnumMember(JsonValue = "Trailer")]
        Trailer,

        [TraktEnumMember(JsonValue = "Teaser")]
        Teaser,

        [TraktEnumMember(JsonValue = "Clip")]
        Clip,

        [TraktEnumMember(JsonValue = "Behind the Scenes", DisplayName = "Behind the Scenes")]
        BehindTheScenes,

        [TraktEnumMember(JsonValue = "Bloopers")]
        Bloopers,

        [TraktEnumMember(JsonValue = "Featurette")]
        Featurette,

        [TraktEnumMember(JsonValue = "Opening Credits")]
        OpeningCredits
    }
}
