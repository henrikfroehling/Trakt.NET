namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class ImageObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""fu"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png""
              }";
    }
}
