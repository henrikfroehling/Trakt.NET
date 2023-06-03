namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    public partial class MovieTranslationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""ov"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tl"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""la"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""ti"": ""Star Wars: Episode VII - The Force Awakens"",
                ""ov"": ""A continuation of the saga created by George Lucas,..."",
                ""tl"": ""The Force Lives On..."",
                ""la"": ""en"",
                ""co"": ""us""
              }";
    }
}
