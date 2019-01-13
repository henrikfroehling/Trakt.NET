namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class ImageArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                },
                {
                  ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                },
                {
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                },
                {
                  ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""fu"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                },
                {
                  ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                },
                {
                  ""fuuull"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""fu"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                },
                {
                  ""fuuull"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
                }
              ]";
    }
}
